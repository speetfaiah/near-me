<template>
    <div class="container">
        <form @submit="searchSubmit">
            <p>
                <label>Lat:</label><br />
                <input type="number" step="any" min="-90" max="90"
                       v-model="lat" />
            </p>
            <p>
                <label>Lon:</label><br />
                <input type="number" step="any" min="-180" max="180"
                       v-model="lon" />
            </p>
            <p>
                <label>Count:</label><br />
                <input type="number" min="10" max="500"
                       v-model="count" />
            </p>
            <p>
                <label>Radius:</label><br />
                <input type="number" min="1000" max="32000"
                       v-model="radius" />
            </p>
            <input type="submit" value="Search!" />
        </form>
    </div>
</template>

<script>
    import { mapActions, mapState } from 'vuex'

    export default {
        name: 'Search',
        computed: {
            ...mapState({
                loadYet: state => state.loadYet,
                page: state => state.page
            }),
            lat: {
                get() {
                    return this.$store.state.lat
                },
                set(value) {
                    this.updateStateProp({ name: 'lat', value: value })
                }
            },
            lon: {
                get() {
                    return this.$store.state.lon
                },
                set(value) {
                    this.updateStateProp({ name: 'lon', value: value })
                }
            },
            count: {
                get() {
                    return this.$store.state.count
                },
                set(value) {
                    this.updateStateProp({ name: 'count', value: value })
                }
            },
            radius: {
                get() {
                    return this.$store.state.radius
                },
                set(value) {
                    this.updateStateProp({ name: 'radius', value: value })
                }
            }
        },
        methods: {
            ...mapActions({
                search: 'search',
                updateStateProp: 'updateStateProp'
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