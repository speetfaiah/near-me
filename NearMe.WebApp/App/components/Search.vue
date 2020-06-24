<template>
    <div class="container">
        <form @submit="searchSubmit">
            <p>
                <label>Count:</label><br />
                <input type="range" min="10" max="500" v-model="count" />
            </p>
            <p>
                <label>Radius:</label><br />
                <template v-for="circleRadius in radiuses">
                    <input type="radio" v-bind:value="circleRadius" v-model="radius">
                    <label>{{circleRadius}}</label>
                    <br />
                </template>
            </p>
            <input type="submit" value="Search!" />
        </form>
    </div>
</template>

<script>
    import { mapActions, mapState } from 'vuex'

    export default {
        name: 'Search',
        data: function () {
            return {
                radiuses: [
                    10, 100, 800, 5000, 6000, 50000
                ]
            }
        },
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
                    this.updateStateProp({ name: 'count', value: parseInt(value) })
                }
            },
            radius: {
                get() {
                    return this.$store.state.radius
                },
                set(value) {
                    this.updateStateProp({ name: 'radius', value: parseInt(value) })
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