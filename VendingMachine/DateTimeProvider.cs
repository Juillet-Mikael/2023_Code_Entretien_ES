using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selling
{
    /// <summary>
    /// Date Time provider is ussed to set custom date time
    /// Is static cause need to be constant every where
    /// Idea coming from this site : https://levelup.gitconnected.com/5-ways-to-mock-datetime-now-for-unit-testing-in-c-bf0438eab032
    /// </summary>
    public static class DateTimeProvider
    {
        private static DateTime _dateTime;
        private static Boolean _isDateTimeSetted = false;

        /// <summary>
        /// Allow to get date time now if value setted return setted value, else reture actual datetime
        /// Allow to set date time on a custom date
        /// </summary>
        public static DateTime Now
        {
            get
            { 
                if (_isDateTimeSetted)
                {
                    return _dateTime;
                }
                else
                {
                    return DateTime.Now;
                }
            }
            set
            {
                _dateTime = value;
                _isDateTimeSetted = true;
            }
        }
    }
}
