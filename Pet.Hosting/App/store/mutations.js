export default {
    updateStateProp(state, prop) {
        state[prop.name] = prop.value;
    },
    search(state, payload) {
        state.photos.push(...payload.data.items);
        state.loadYet = payload.data.hasPhotosYet;
        state.page++;
    }
}