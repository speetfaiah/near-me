<template>
    <div>
        <div class="message-section">
            <img v-for="image in photos" :src="image.smallPhotoUrl" :alt="image.description" />
        </div>
        <button v-if="loadMore" @click="searchSubmit">More!</button>
    </div>
</template>

<script>
    import { mapActions, mapState } from 'vuex'

    export default {
        name: 'List',
        computed: mapState([
            'lat',
            'lon',
            'count',
            'page',
            'radius',
            'loadMore',
            'photos'
        ]),
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
                    loadMore: this.loadMore
                });
            }
        }
    }
</script>