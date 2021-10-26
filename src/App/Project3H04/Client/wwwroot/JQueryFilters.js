


function initializeFilters() {
    //select input fields with class form-check

    var $filterCheckboxes = $("input.form-check-input:checkbox");

    //when $filterCheckboxes is changed this function will be called

    var filterFunc = function () {
        var selectedFilters = {};

        $filterCheckboxes.filter(':checked').each(function () {

            if (!selectedFilters.hasOwnProperty(this.name)) {
                selectedFilters[this.name] = [];
            }
            // push selected filter value in SelectedFilters

            selectedFilters[this.name].push(this.value);

        });

        // create a collection containing all of the filterable elements: <div class="artwork">

        var $filteredResults = $('.artworks');

        // loop over the selected filter name -> (array) values pairs

        $.each(selectedFilters, function (name, filterValues) {

            // $filteredResults contains the gallery photos divs

            $filteredResults = $filteredResults.filter(function () {

                var matched = false
                var currentFilterValues = $(this).data('category').split(' ');

                // currentFilterValues = category values
                // loop over each category value in the current data-category of the gallery

                $.each(currentFilterValues, function (_, currentFilterValue) {
                    // if the current category exists in the selected filters array
                    // set matched to true, and stop looping
                    // set of filters, we only need to match once
                    // $inArray will return -1 if not found

                    if ($.inArray(currentFilterValue, filterValues) != -1) {
                        matched = true;
                        return false;
                    }
                });


                // if matched is true the current .artwork element is returned

                return matched;

            }
            );

        });
        $('.artworks').hide().filter($filteredResults).show();
    }

    //click event

    $filterCheckboxes.on('click', filterFunc);

};
