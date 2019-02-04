<template>
    <div class="BooksList">
        <h1>Add new book</h1>
            <p v-if="errors.length">
                <b>Please correct the following error(s):</b>
                <ul>
                    <li v-for="error in errors">{{ error }}</li>
                </ul>
            </p>
            <form>
                <div>
                    <label>Title</label>
                    <input v-model="title" placeholder="Title" type="text">
                </div>
                <div>
                    <label>Publication date</label>
                    <input v-model="publicationDate" placeholder="Publication date" type="date">
                </div>
                <div>
                    <label>Price</label>
                    <vue-numeric currency="PLN" separator=" " v-bind:min="0" v-bind:precision="2" v-model="price" placeholder="Price"></vue-numeric>
                </div>
                <div>
                    <label>Quantity</label>
                    <input v-model="quantity" v-bind:min="0" placeholder="Quantity" type="number">
                </div>
                <button class="submit" v-on:click.prevent="post">Add book</button>
            </form>
    </div>
</template>

<script>
    import VueNumeric from 'vue-numeric'
    export default {
        name: 'BooksList',
        components: {
            VueNumeric
        },
        data() {
            return {
                errors: [],
                title: '',
                publicationDate: '',
                price: '',
                quantity: ''
            }
        },
        methods: {
            post: function () {
                if (this.checkForm()) {
                    this.$http.post('http://localhost:29587/api/books', {
                        title: this.title,
                        publicationDate: this.publicationDate,
                        price: this.price,
                        quantity: this.quantity
                    }).then(function (data) {
                        console.log(data);
                    })
                    this.title = "";
                    this.publicationDate = "";
                    this.price = "";
                    this.quantity = "";
                    this.errors = [];
                }
            },
            checkForm: function (e) {
                if (this.title && this.publicationDate && this.price > 0 && this.quantity > 0) {
                    return true;
                }

                this.errors = [];

                if (!this.title) 
                    this.errors.push('Title required.');
                if (!this.publicationDate) 
                    this.errors.push('Publication date required.');
                if (!this.price) 
                    this.errors.push('Price required.');
                else if (this.price < 0)
                    this.errors.push('Price cannot be negative.');
                if (!this.quantity) 
                    this.errors.push('Quantity required.');
                 else if (this.quantity < 0) 
                    this.errors.push('Quantity cannot be negative.');
                

                e.preventDefault();
            }
        }
    };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    .BooksList{
        max-width:500px;
    }
    .single-book{
        padding: 20px;
        margin: 20px;
        box-sizing: border-box;
        background: #d0d0d0;
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
