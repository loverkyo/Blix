//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MODEL
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_LensIndex
    {
        public T_LensIndex()
        {
            this.T_Lens = new HashSet<T_Lens>();
        }
    
        public int ID { get; set; }
        public string LensIndex { get; set; }
        public Nullable<decimal> LensIndexPriceRMB { get; set; }
        public Nullable<decimal> LensIndexPriceUSD { get; set; }
    
        public virtual ICollection<T_Lens> T_Lens { get; set; }
    }
}
