import Vue from 'vue'
import Index from './pages/Index.vue'
import store from './store'

new Vue({
    el: '#app-container',
    store,
    render: h => h(Index)
})