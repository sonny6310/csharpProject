using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apartment
{
    // listview Column 클릭 시 정렬 메소드.
    // 기본적으로 listview는 문자열 정렬이므로 숫자 정렬이 정상적으로 되지 않음.
    // 따라서 IComparer 인터페이스를 상속받아서 숫자정렬도 가능하도록 구현.
    // 숫자정렬을 할 Column은 tag에 Numeric으로 입력해야 함.
    class Sorter : System.Collections.IComparer
    {
        public int Column = 0;
        public System.Windows.Forms.SortOrder Order = System.Windows.Forms.SortOrder.Ascending;
        public int Compare(object x, object y) // IComparer Member
        {
            if (!(x is ListViewItem))
                return (0);
            if (!(y is ListViewItem))
                return (0);

            ListViewItem l1 = (ListViewItem)x;
            ListViewItem l2 = (ListViewItem)y;

            if (l1.ListView.Columns[Column].Tag == null) // 리스트뷰 Tag 속성이 Null 이면 기본적으로 Text 정렬을 사용하겠다는 의미
            {
                l1.ListView.Columns[Column].Tag = "Text";
            }

            if (l1.ListView.Columns[Column].Tag.ToString() == "Numeric") // 리스트뷰 Tag 속성이 Numeric 이면 숫자 정렬을 사용하겠다는 의미
            {

                string str1 = l1.SubItems[Column].Text;
                string str2 = l2.SubItems[Column].Text;

                if (str1 == "")
                {
                    str1 = "99999";
                }
                if (str2 == "")
                {
                    str2 = "99999";
                }

                float fl1 = float.Parse(str1);    //숫자형식으로 변환해서 비교해야 숫자정렬이 되겠죠?
                float fl2 = float.Parse(str2);    //숫자형식으로 변환해서 비교해야 숫자정렬이 되겠죠?

                if (Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    return fl1.CompareTo(fl2);
                }
                else
                {
                    return fl2.CompareTo(fl1);
                }
            }
            else
            {                                             // 이하는 텍스트 정렬 방식
                string str1 = l1.SubItems[Column].Text;
                string str2 = l2.SubItems[Column].Text;

                if (Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    return str1.CompareTo(str2);
                }
                else
                {
                    return str2.CompareTo(str1);
                }
            }
        }
    }
}
