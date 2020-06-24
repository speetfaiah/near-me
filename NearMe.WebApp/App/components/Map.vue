<template>
    <div class="container">
        <div id="map"></div>
    </div>
</template>

<style scoped>
    #map {
        width: 100%;
        height: 100%;
        padding: 0;
        margin: 0;
        min-width: 500px;
        min-height: 500px;
    }
</style>

<script>
    import { mapActions, mapState } from 'vuex'

    export default {
        name: 'Map',
        data: function () {
            return {
                map: null,
                circle: null
            }
        },
        computed:
        {
            ...mapState([
                'radius',
                'photos'
            ]),
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
            }
        },
        methods: {
            ...mapActions({
                search: 'search',
                updateStateProp: 'updateStateProp'
            }),
            initMap: function () {
                var self = this;
                ymaps.ready(function () {
                    var yMap = new ymaps.Map("map", {
                        center: [self.lat, self.lon],
                        zoom: 10
                    });

                    var yCircle = new ymaps.Circle([
                        [self.lat, self.lat],
                        self.radius
                    ], null, {
                        geodesic: true,
                        draggable: true,
                        fillColor: "#DB709377",
                        strokeColor: "#990066",
                        strokeOpacity: 0.8,
                        strokeWidth: 3
                    });

                    yCircle.events.add([
                        'dragend'
                    ], function (e) {
                        var coords = yCircle.geometry.getCoordinates();
                        self.lat = coords[0];
                        self.lon = coords[1];
                    });

                    yMap.geoObjects.add(yCircle);

                    self.map = yMap;
                    self.circle = yCircle;
                });
            },
            updatePoints: function () {
                if (this.photos) {

                    // this.map.geoObjects.removeAll();
                    // this.map.geoObjects.add(this.map.circle);

                    var placemarkCollection = new ymaps.GeoObjectCollection(null, {
                        preset: 'islands#greenDotIconWithCaption'
                    });

                    for (var i = 0; i < this.photos.length; i++) {
                        var placemark = mapPhotoToPlacemark(this.photos[i]);
                        placemarkCollection.add(placemark);
                    }

                    this.map.geoObjects.add(placemarkCollection);
                }
            },
            updateCircle: function () {
                this.circle.geometry.setRadius(this.radius);

                // this.map.geoObjects.removeAll();
                //this.map.geoObjects.add(this.map.circle);
            },
        },
        mounted: function () {
            this.$nextTick(function () {
                this.initMap();
            })
        },
        watch: {
            photos(newValue, oldValue) {
                this.updatePoints();
            },
            radius(newValue, oldValue) {
                this.updateCircle();
            }
        }
    }

    function mapPhotoToPlacemark(photo) {
        /* {
     description: "",
     date: "",
     lat: 0,
     lon: 0,
     siteUrl: "",
     smallPhotoUrl: "",
     bigPhotoUrl: ""
    } */
        return new ymaps.Placemark([photo.lat, photo.lon], {
            balloonContent: '<a href="' + photo.siteUrl + '"><img src="' + photo.smallPhotoUrl + '" /></a>',
            iconCaption: photo.description
        }, {
            preset: 'islands#greenDotIconWithCaption'
        })
    }
</script>