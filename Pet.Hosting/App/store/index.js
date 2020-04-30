import Vue from 'vue'
import Vuex from 'vuex'
import * as getters from './getters'
import * as actions from './actions'
import mutations from './mutations'

Vue.use(Vuex)

const state = {   
    lat: 60,
    lon: 60,
    count: 60,
    page: 0,
    radius: 1000,
    photos: [
        /* {
             description: "",
             date: "",
             lat: 0,
             lon: 0,
             siteUrl: "",
             smallPhotoUrl: "",
             bigPhotoUrl: "" 
        } */ ],
    loadYet: true
}

export default new Vuex.Store({
    state,
    getters,
    actions,
    mutations
})