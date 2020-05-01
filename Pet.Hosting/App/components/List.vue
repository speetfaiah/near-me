<template>
    <div>
        <div class="message-section">
            <img v-for="image in photos" :src="image.smallPhotoUrl" :alt="image.description" />
        </div>
        <button v-if="loadYet" @click="searchSubmit">Yet!</button>
    </div>
</template>

<script>
    import { mapActions, mapState } from 'vuex'

    export default {
        name: 'List',
        computed: mapState({
            lat: state => state.lat,
            lon: state => state.lon,
            count: state => state.count,
            page: state => state.page,
            radius: state => state.radius,
            loadYet: state => state.loadYet,
            photos: state => state.photos
        }),
        methods: {
            ...mapActions({
                search: 'search'
            }),
            searchSubmit: function (e) {
                e.preventDefault();
                this.search({
                    lat: this.lat,
                    lon: this.lon,
                    count: this.count,
                    page: this.page,
                    radius: this.radius,
                    loadYet: this.loadYet
                });
            }
        }
    }
</script>