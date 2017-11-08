function getDateRange(referenceDate, type) {
    var lowerBound = moment(referenceDate);
    var upperBound = moment(referenceDate);
    switch (type) {
        case "LastTenYears":
            return { "LowerBound": lowerBound.subtract(10, "years").startOf("years"), "UpperBound": upperBound };
            break;
        case "LastFiveYears":
            return { "LowerBound": lowerBound.subtract(5, "years").startOf("years"), "UpperBound": upperBound };
            break;
        case "LastYear":
            return { "LowerBound": lowerBound.subtract(1, "years").startOf("years"), "UpperBound": upperBound };
            break;
        case "LastSixMonths":
            return { "LowerBound": lowerBound.subtract(6, "months").startOf("months"), "UpperBound": upperBound };
            break;
        case "LastThreeMonths":
            return { "LowerBound": lowerBound.subtract(3, "months").startOf("months"), "UpperBound": upperBound };
            break;
        case "LastMonth":
            return { "LowerBound": lowerBound.subtract(1, "months").startOf("months"), "UpperBound": upperBound };
            break;
        case "LastWeek":
            return { "LowerBound": lowerBound.subtract(1, "weeks").startOf("weeks"), "UpperBound": upperBound };
            break;
        case "Yesterday":
            return { "LowerBound": lowerBound.subtract(1, "days").startOf("days"), "UpperBound": upperBound };
            break;
        case "ThisYear":
            return { "LowerBound": lowerBound.startOf("years"), "UpperBound": upperBound.endOf("years") };
            break;
        case "ThisMonth":
            return { "LowerBound": lowerBound.startOf("months"), "UpperBound": upperBound.endOf("months") };
            break;
        case "ThisWeek":
            return { "LowerBound": lowerBound.startOf("weeks"), "UpperBound": upperBound.endOf("weeks") };
            break;
        case "Today":
            return { "LowerBound": lowerBound.startOf("days"), "UpperBound": upperBound.endOf("days") };
            break;
        case "Tomorrow":
            return { "LowerBound": lowerBound.add(1, "days").startOf("days"), "UpperBound": upperBound.add(1, "days").endOf("days") };
            break;
        case "NextWeek":
            return { "LowerBound": lowerBound.add(1, "weeks").startOf("weeks"), "UpperBound": upperBound.add(1, "weeks").endOf("weeks") };
            break;
        case "NextMonth":
            return { "LowerBound": lowerBound.add(1, "months").startOf("months"), "UpperBound": upperBound.add(1, "months").endOf("months") };
            break;
        case "NextThreeMonths":
            return { "LowerBound": lowerBound, "UpperBound": upperBound.add(3, "months").endOf("months") };
            break;
        case "NextSixMonths":
            return { "LowerBound": lowerBound, "UpperBound": upperBound.add(6, "months").endOf("months") };
            break;
        case "NextYear":
            return { "LowerBound": lowerBound, "UpperBound": upperBound.add(1, "years").endOf("years") };
            break;
        case "NextFiveYears":
            return { "LowerBound": lowerBound, "UpperBound": upperBound.add(5, "years").endOf("years") };
            break;
        case "NextTenYears":
            return { "LowerBound": lowerBound, "UpperBound": upperBound.add(10, "years").endOf("years") };
            break;
    }
}
function preDefinedDateTimeRangeChanged(masterName) {
    var thisInput = $('select[name="' + masterName + '.PreDefinedDateTimeRange"]');
    var inputLowerBound = $('input[name="' + masterName + '.NullableLowerBound"]');
    var inputUpperBound = $('input[name="' + masterName + '.NullableUpperBound"]');
    if ($(thisInput).val() == 'Custom') {
        inputLowerBound.prop('disabled', false);
        inputUpperBound.prop('disabled', false);
    }
    else {
        inputLowerBound.prop('disabled', true);
        inputUpperBound.prop('disabled', true);

        var range = getDateRange(moment(), $(thisInput).val());
        inputLowerBound.val(range.LowerBound.format('MM/DD/YYYY'));
        inputUpperBound.val(range.UpperBound.format('MM/DD/YYYY'));
    }
}