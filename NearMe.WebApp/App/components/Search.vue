<template>
    <div class="container">
        <form @submit="searchSubmit">
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
            ...mapState([
                'lat',
                'lon',
                'hasMore',
                'page'
            ]),
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
                    hasMore: this.hasMore
                });
            }
        }
    }
</script>