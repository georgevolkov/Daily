// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    new Vue({
        el: '#models',
        data: {
            models: false,
            seen: true,
            show: true,
            loader: false,
            notFound: false,
            page: 1,
            bottom: false,
            displayBlock: '',
            sort_selected: '',
            query: '',
            items: []
        },
        methods: {
            // this method need for hide and show search input (toogle method), sets the value of show
            getWindowWidth(event) {
                var windowWidth = document.documentElement.clientWidth;
                if (windowWidth >= 1050) {
                    this.show = false;
                    this.displayBlock = 'block';
                }
                else {
                    this.show = true;
                    this.displayBlock = '';
                }
            },
            toggle: function () {
                this.show = !this.show;
                return this.displayBlock = !this.show === true ? 'block' : '';
            },
            getQuery: function () {
                return document.querySelector("input[name=query]").value;
            },
            getCategory: function () {
                return document.getElementById("selected").value;
            },
            isLoading(state) {
                return this.loader = state;
            },
            bottomVisible() {
                const scrollY = window.scrollY;
                const visible = document.documentElement.clientHeight;
                const pageHeight = document.documentElement.scrollHeight;
                const bottomOfPage = visible + scrollY >= pageHeight;
                return bottomOfPage || pageHeight < visible;
            },
            addItems() {
                // without _this variable push method don't work
                var _this = this;
                this.isLoading(true);
                axios.get(`/Home/GetData/?pageNumber=${this.page}&query=${this.getQuery()}`)
                    .then((response) => {
                        if (response.data.data.length > 0) {
                            this.notFound = false;
                            this.seen = true;
                            console.log(response);
                            response.data.data.forEach(function (item) {
                                item.url = `/Home/About/?answerId=${item.id}`;
                                _this.items.push(item);
                            });
                            this.page++;
                        }
                        if (response.data.filtered === 0 && response.data.total === 0) {
                            this.seen = false;
                            this.notFound = true;
                        }
                        this.isLoading(false);
                        this.models = true;
                    },
                        (error) => {
                            this.models = true;
                            this.seen = false;
                            this.notFound = true;
                            this.isLoading(false);
                        });
            }
        },
        watch: {
            query: function () {
                this.page = 1;
                this.items.length = 0;
                this.addItems();
            },
            selected: function (val) {
                this.page = 1;
                this.items.length = 0;
                this.addItems();
            },
            bottom(bottom) {
                if (bottom) {
                    this.addItems();
                }
            }
        },
        mounted() {
            this.$nextTick(function () {
                this.getWindowWidth();
            });  
        },
        created() {
            window.addEventListener('scroll', () => {
                this.bottom = this.bottomVisible();
            });
            this.addItems();
        },
        beforeDestroy() {
            window.removeEventListener('resize', this.getWindowWidth);
            window.removeEventListener('scroll');
        }
    });
});