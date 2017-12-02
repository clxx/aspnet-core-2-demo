new Vue({
    el: '#app',
    data: {
        red: 0,
        green: 0,
        blue: 0,
        name: 'black'
    },
    watch: {
        red: function () { this.name = this.getName() },
        green: function () { this.name = this.getName() },
        blue: function () { this.name = this.getName() }
    },
    methods: {
        validateForm: function () {
            var form = $('#color');
            $.extend(form.validate().settings, {
                highlight: function (element) {
                    $(element).addClass('is-invalid');
                },
                unhighlight: function (element) {
                    $(element).removeClass('is-invalid');
                },
                errorElement: 'div',
                errorClass: 'form-group invalid-feedback',
                errorPlacement: function (error, element) {
                    error.insertAfter(element.closest('.input-group'));
                }
            });
            return form.valid();
        },
        getName: function () {
            if (!this.validateForm()) {
                return "Invalid..."
            }
            axios.get('/Color/Get', {
                params: {
                    red: this.red,
                    green: this.green,
                    blue: this.blue
                }
            }).then(response => {
                this.name = response.data;
            }).catch(error => {
                this.name = 'Error...';
            });
            return 'Computing...';
        }
    }
})