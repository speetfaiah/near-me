<template>
    <div class="container">
        <div class="row">
            <div class="col-4">
                <search></search>
            </div>
            <div class="col-8">
                <ya-map></ya-map>
            </div>
        </div>
        <div class="row">
            <list></list>
        </div>
    </div>
</template>

<script>
    import Search from '../components/Search.vue'
    import Map from '../components/Map.vue'
    import List from '../components/List.vue'

    export default {
        name: 'index',
        components: {
            'search': Search,
            'ya-map': Map,
            'list': List
        },
        data() {
            return {
                message: 'Welcome to Vue.js'
            }
        }
    }
</script>