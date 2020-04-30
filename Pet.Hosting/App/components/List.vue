<template>
    <div>
        <div class="message-section">
            <img v-for="image in $store.state.photos" :src="image.smallPhotoUrl" :alt="image.description" />
        </div>
        <button v-if="$store.state.loadYet" @click="loadYet">Yet!</button>
    </div>
</template>

<script>
    import { mapActions, mapGetters } from 'vuex'

    export default {
        name: 'List',
        methods: {
            ...mapActions({
                loadYet: 'search'
            }),
            searchSubmit: function (e) {
                e.preventDefault();
                this.search({
                    lat: this.lat,
                    lon: this.lon,
                    count: this.count,
                    page: this.page,
                    radius: this.radius
                });
            }
        }
    }
</script>