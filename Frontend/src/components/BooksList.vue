<template>
    <div class="BooksList">
        <h1>Books list</h1>
        <table style="width:500px;">
            <thead>
                <tr>
                    <td>Title</td>
                    <td>Publication date</td>
                    <td>Price</td>
                    <td>Quantity</td>
                </tr>
            </thead>
            <tbody>
                <tr v-for="book in books" class="single-book">
                    <td>{{book.title}}</td>
                    <td>{{book.publicationDate.toString().split('T')[0].split('-').reverse().join('/')}}</td>
                    <td>{{book.price}}</td>
                    <td>{{book.quantity}}</td>
                </tr>
            </tbody>
        </table>
        <div>
            <div style="float: left"v-if="currentPage > 1" @click="previousPage">
                <<
            </div>
            <div  style="float: left" v-else>
                <<
            </div>
            <div style="float: left">  {{currentPage}}/{{pageCount}}  </div>
            <div style="float: left" v-if="currentPage < pageCount" @click="nextPage">
                >>
            </div>
            <div style="float: left" v-else>
                >>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'BooksList',
        data() {
            return {
                currentPage: 1,
                pageCount: "",
                books: []
            }
        },
        created() {
            this.get(1);
        },
        methods: {
            previousPage: function () {
                if (this.currentPage > 1)
                    this.currentPage--;
                this.get(this.currentPage);
            },
            nextPage: function () {
                if (this.currentPage < this.pageCount)
                    this.currentPage++;
                this.get(this.currentPage);
            },
            get: function (page) {
                this.$http.get('http://localhost:29587/api/books' + "?page=" + page)
                    .then(function (data) {
                        console.log(data.body);
                        this.books = data.body.books;
                        this.pageCount = data.body.pageCount;
                        this.currentPage = data.body.currentPage;
                    }
                    )
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
        background: #ebebeb;
    }
    table {
        border-collapse: collapse;
        width: 100%;
    }

    thead, td {
        text-align: left;
        padding: 8px;
    }

    tr:nth-child(even) {
        background-color: white;
    }

    thead {
        background-color: #4CAF50;
        color: white;
    }
</style>
