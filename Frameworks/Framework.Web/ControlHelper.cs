using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Framework.Web
{
    public static class ControlHelper
    {
        /// <summary>
        /// Wyszukanie formantu w drzewie formantów wskazanego formantu
        /// </summary>
        /// <param name="control"></param>
        /// <param name="IdToFind"></param>
        /// <returns></returns>
        public static Control Find( Control control, string IdToFind )
        {
            if ( !string.IsNullOrEmpty( IdToFind ) )
            {
                if ( control.ID == IdToFind )
                {
                    return control;
                }
                foreach ( Control child in control.Controls )
                {
                    Control result = Find( child, IdToFind );
                    if ( result != null )
                    {
                        return result;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Wyszukanie formantu w drzewie formantów wskazanego formantu
        /// </summary>
        public static Control Find( Control control, Predicate<Control> MatchPredicate )
        {
            if ( MatchPredicate( control ) )
            {
                return control;
            }
            foreach ( Control child in control.Controls )
            {
                Control result = Find( child, MatchPredicate );
                if ( result != null )
                {
                    return result;
                }
            }
            return null;
        }

        /// <summary>
        /// Wyszukanie formantów w drzewie formantów wskazanego formantu
        /// </summary>
        public static Control[] FindAll( Control Parent, Predicate<Control> MatchPredicate )
        {
            List<Control> ret = new List<Control>();

            FindAllHelper( Parent, MatchPredicate, ret );

            return ret.ToArray();
        }

        private static void FindAllHelper( Control Parent, Predicate<Control> MatchPredicate, List<Control> results )
        {
            if ( MatchPredicate( Parent ) )
                results.Add( Parent );
            // rekursja
            foreach ( Control child in Parent.Controls )
            {
                FindAllHelper( child, MatchPredicate, results );
            }
        }
    }
}