<template>
    <div class="Chat">
        <h1>Chat</h1>
        <div class="form-group">
            <form>
                <ul >
                    <li v-for="(item, index) in messages" v-bind:key="index + 'itemMessage'"><b>{{item.user}}:</b>{{item.message}}</li>
                </ul>
                <div>
                    <label for="userName">Your Name</label>
                    <input type="text" name="Name" id="userName" v-model="userName">
                </div>
                <div>
                    <label for="userMessage">Message</label>
                    <input type="text" name="Message" id="userMessage" v-model="userMessage">
                </div>
                <button class="submit" v-on:click="submitCard" type="button">Submit</button>
            </form>
        </div>
    </div>
</template>

<script>
    const SignalR = require('@aspnet/signalr');
    export default {
        name: "Chat",
        data() {
            return {
                userName: "",
                userMessage: "",
                connection: "",
                messages: []}
            },
        methods: {
            submitCard: function () {
                if (this.userName && this.userMessage) {
                    // ---------
                    //  Call hub methods from client
                    // ---------
                    this.connection
                        .invoke("SendMessage", this.userName, this.userMessage)
                        .catch(function (err) {
                            return console.error(err.toSting());
                        });
                    
                    this.userMessage = "";
                }
            }
        },
        created: function () {
            // ---------
            // Connect to our hub
            // ---------
            this.connection = new SignalR.HubConnectionBuilder()
                .withUrl("http://localhost:29587/chatHub")
                .configureLogging(SignalR.LogLevel.Information)
                .build();
            this.connection.start().catch(function (err) {
                return console.error(err.toSting());
            });
        },
        mounted: function () {
            // ---------
            // Call client methods from hub
            // ---------
            var thisVue = this;
            thisVue.connection.start();
            thisVue.connection.on("RecieveMessage", function (user, message) {
                thisVue.messages.push({ user, message });
            });
        }
    };

</script>
<style>
    ul {
        height: 200px;
        width:250px;
        overflow: hidden;
        overflow-y: scroll;
    }
    li {
        list-style-type: none;
        word-wrap: break-word;
    }
    input, select {
        width: 100%;
        padding: 12px 20px;
        margin: 8px 0;
        display: inline-block;
        border: 1px solid #ccc;
        border-radius: 4px;
        box-sizing: border-box;
    }
    button[class=submit] {
        width: 100%;
        background-color: #4CAF50;
        color: white;
        padding: 14px 20px;
        margin: 8px 0;
        border: none;
        border-radius: 4px;
        cursor: pointer;
    }
    button[class=submit]:hover {
        background-color: #45a049;
    }
</style>