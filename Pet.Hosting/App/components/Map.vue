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
        computed:
        {
            ...mapState({
                lat: state => state.lat,
                lon: state => state.lon,
                radius: state => state.radius,
                photos: state => state.photos
            }),
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
                    init(self.lat, self.lon, self.radius, self.photos);
                });
            }
        },
        mounted: function () {
            this.$nextTick(function () {
                this.initMap();
            })
        },
        watch: {
            needUpdateMap(newValue, oldValue) {
                console.log(`Updating needMapUpdate from ${oldValue} to ${newValue}`);
                this.initMap();
            }
        }
    }

    function init(lat, lon, radius, photos) {
        var myMap = new ymaps.Map("map", {
            center: [lat, lon],
            zoom: 10
        });

        myMap.geoObjects
            .add(new ymaps.Placemark([55.782392, 37.614924], {
                balloonContent: 'цвет <strong>детской неожиданности</strong>',
                iconCaption: 'Очень длиннный, но невероятно интересный текст'
            }, {
                preset: 'islands#circleDotIcon',
                iconColor: 'yellow',
                iconCaptionMaxWidth: '50'
            }))
            .add(new ymaps.Placemark([55.694843, 37.435023], {
                balloonContent: 'цвет <strong>носика Гены</strong>',
                iconCaption: 'Очень длиннный, но невероятно интересный текст'
            }, {
                preset: 'islands#greenDotIconWithCaption'
            }));
    }
</script>