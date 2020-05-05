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
        min-width: 300px;
        min-height: 300px;
    }
</style>

<script>
    import { mapActions, mapState, mapGetters } from 'vuex'

    export default {
        name: 'Map',
        data: function () {
            return {
                map: null
            }
        },
        computed:
        {
            ...mapState([
                'lat',
                'lon',
                'radius',
                'photos'
            ]),
            ...mapGetters([
                'needUpdateMap'
            ])
        },
        methods: {
            ...mapActions({
                search: 'search'
            }),
            initMap: function () {
                var self = this;
                ymaps.ready(function () {
                    self.map = new ymaps.Map("map", {
                        center: [self.lat, self.lon],
                        zoom: 10
                    });
                });
            },
            updateMap: function () {
                this.map.setCenter([this.lat, this.lon]);
            },
            updatePoints: function () {
                if (this.photos) {
                    var placemarkCollection = new ymaps.GeoObjectCollection(null, {
                        preset: 'islands#greenDotIconWithCaption'
                    });

                    for (var i = 0; i < this.photos.length; i++) {
                        var placemark = mapPhotoToPlacemark(this.photos[i]);
                        placemarkCollection.add(placemark);
                    }

                    this.map.geoObjects.add(placemarkCollection);
                }
            }
        },
        mounted: function () {
            this.$nextTick(function () {
                this.initMap();
            })
        },
        watch: {
            needUpdateMap(newValue, oldValue) {
                this.updateMap();
            },
            photos(newValue, oldValue) {
                this.updatePoints();
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