using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniWeibo.Net.Common
{
    using System.Collections;

    public class WeiboEntities : IEnumerable<WeiboEntity>
    {
        #region Implementation of IEnumerable

        public IEnumerator<WeiboEntity> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }

    public class WeiboEntity : IComparable<WeiboEntity>, IComparer<WeiboEntity>
    {
        public virtual IList<int> Indices { get; set; }

        public virtual WeiboEntityType EntityType { get; set; }

        public virtual int StartIndex { get { return Indices.Count > 0 ? Indices[0] : -1; } }

        #region Implementation of IComparable<WeiboEntity>

        public int CompareTo(WeiboEntity other)
        {
            return StartIndex.CompareTo(other.StartIndex);
        }

        #endregion

        #region Implementation of IComparer<WeiboEntity>

        public int Compare(WeiboEntity x, WeiboEntity y)
        {
            return x.StartIndex.CompareTo(y.StartIndex);
        }

        #endregion
    }
}
