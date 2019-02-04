<template>
    <div id="app">
        <div class="wrapper">
            <AddBook></AddBook>
            <BooksList></BooksList>
            <Chat></Chat>
        </div>
</div>
</template>

<script>
    import BooksList from './components/BooksList.vue';
    import AddBook from './components/AddBook.vue';
    import Chat from './components/Chat.vue';

    export default {
        name: 'app',
        components: {
            BooksList,
            AddBook,
            Chat
        }
    };
</script>

<style>
    body{
        margin:100px;
    }
    AddBook { 
        grid-area:left;
    }
    BooksList {
        grid-area:main;
    }
    Chat {
        grid-area:right;
    }
    .wrapper { 
        display: grid; grid-template-areas: 'left main main main right right'; grid-gap: 10px; color: #444; 
    }
</style>
