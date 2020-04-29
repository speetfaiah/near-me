<template>
    <div className="container">
        Clicked: {{ $store.state.count }} times, count is {{ evenOrOdd }}.
        <button @click="increment">+</button>
    </div>
</template>

<script>
    import { mapActions, mapGetters } from 'vuex'

    export default {
        name: 'Search',
        computed: mapGetters([
            'evenOrOdd'
        ]),
        methods: mapActions([
            'increment'
        ])
    }
</script>