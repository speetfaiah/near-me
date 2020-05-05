export default {
    updateStateProp(state, prop) {
        state[prop.name] = prop.value;
        state.loadMore = false;
        state.page = 0;
    },
    search(state, payload) {
        if (payload.newSearch) {
            state.photos = payload.data.items;
        } else {
            state.photos.push(...payload.data.items);
        }
        
        state.loadMore = payload.data.hasMorePhotos;
        state.page++;
    }
}