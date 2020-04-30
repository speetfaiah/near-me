import axios from 'axios';

export const search = ({ commit }, payload) => {
    axios.post('/api/vk', {
        lat: payload.lat,
        lon: payload.lon,
        count: payload.count,
        radius: payload.radius,
        page: payload.page
    })
        .then(function (response) {
            commit('search', response.data);
        })
        .catch(function (error) {
            console.log(error);
        });
}

export const updateStateProp = ({ commit }, payload) => {
    commit('updateStateProp', payload);
}