export default {
    updateStateProp(state, prop) {
        state[prop.name] = prop.value;
        state.loadYet = false;
        state.page = 0;
    },
    search(state, payload) {
        if (payload.newSearch) {
            state.photos = payload.data.items;
        } else {
            state.photos.push(...payload.data.items);
        }
        
        state.loadYet = payload.data.hasPhotosYet;
        state.page++;
    }
}