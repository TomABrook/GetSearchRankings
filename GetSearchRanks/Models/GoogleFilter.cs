using System;
namespace GetSearchRanks.Models
{
    public class GoogleFilter : SearchFilter
    {
        public GoogleFilter(int NumResults) : base(NumResults)
        {
            // Empty string will indicate any time
            this.TimePeriod = "";
        }

        // Assign user selection to it's url specific character
        public override void SetTimePeriod(string selection)
        {
            switch (selection) {
                case "Year":
                    this.TimePeriod = "y";
                    break;
                case "Month":
                    this.TimePeriod = "m";
                    break;
                case "Week":
                    this.TimePeriod = "w";
                    break;
                case "Day":
                    this.TimePeriod = "d";
                    break;
                default:
                    this.TimePeriod = "";
                    break;
            }
        }

        public string GetTimePeriod() {
            return this.TimePeriod;
        }

        // List of filter options to be displayed to the user
        public override string[] TimePeriodOptions()
        {
            string[] options = {"Any", "Year", "Month", "Day"};

            return options;
        }
    }
}
