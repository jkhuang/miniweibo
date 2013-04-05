/*********************************************************************
 * Project Name : MiniWeibo SDK
 * File Name    : WeiboCursorList.cs
 * Copyright (c): Jackson Huang
 * Description  : 
 * Reference    : 
 * Author       : Jackson Huang
 * Email        : j.k.jackson023{AT}gmail.com ( {AT} -> @ )
 * Blog         : http://www.cnblogs.com/rush/
 * Create On    : 2013-01-14 09:46:23
 * *******************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MiniWeibo.Net.Common
{
    [Serializable]
    public class WeiboCursorList<T> : List<T>, ICursored, INumbered, IVisiable
    {
        [DataMember]
        public virtual long? NextCursor { get; set; }

        [DataMember]
        public virtual long? PreviousCursor { get; set; }

        [DataMember]
        public long? TotalNumber { get; set; }

        [DataMember]
        public bool? HasVisible { get; set; }

        public WeiboCursorList(IEnumerable<T> collection)
            : base(collection)
        {

        }

        public WeiboCursorList(IEnumerable collection)
        {
            foreach (var item in collection)
            {
                Add((T)item);
            }
        }
    }

    ////[Serializable]
    ////public class WeiboCursorList<T, U> : List<T>, ICursored, INumbered, IVisiable
    ////{
    ////    [DataMember]
    ////    public virtual long? NextCursor { get; set; }

    ////    [DataMember]
    ////    public virtual long? PreviousCursor { get; set; }

    ////    [DataMember]
    ////    public long? TotalNumber { get; set; }

    ////    [DataMember]
    ////    public bool? HasVisible { get; set; }

    ////    public WeiboCursorList(IEnumerable<T> collection)
    ////        : base(collection)
    ////    {

    ////    }

    ////    public WeiboCursorList(IEnumerable collection)
    ////    {
    ////        foreach (var item in collection)
    ////        {
    ////            Add((T)item);
    ////        }
    ////    }

    ////    ////IEnumerator<T> IEnumerable<T>.GetEnumerator()
    ////    ////{
    ////    ////    throw new NotImplementedException();
    ////    ////}

    ////    ////public IEnumerator<U> GetEnumerator()
    ////    ////{
    ////    ////    throw new NotImplementedException();
    ////    ////}

    ////    ////public void Add(U item)
    ////    ////{
    ////    ////    throw new NotImplementedException();
    ////    ////}

    ////    ////void ICollection<U>.Clear()
    ////    ////{
    ////    ////    throw new NotImplementedException();
    ////    ////}

    ////    ////public bool Contains(U item)
    ////    ////{
    ////    ////    throw new NotImplementedException();
    ////    ////}

    ////    ////public void CopyTo(U[] array, int arrayIndex)
    ////    ////{
    ////    ////    throw new NotImplementedException();
    ////    ////}

    ////    ////public bool Remove(U item)
    ////    ////{
    ////    ////    throw new NotImplementedException();
    ////    ////}

    ////    ////int ICollection<U>.Count { get; private set; }

    ////    ////public void Add(T item)
    ////    ////{
    ////    ////    throw new NotImplementedException();
    ////    ////}

    ////    ////void ICollection<T>.Clear()
    ////    ////{
    ////    ////    throw new NotImplementedException();
    ////    ////}

    ////    ////public bool Contains(T item)
    ////    ////{
    ////    ////    throw new NotImplementedException();
    ////    ////}

    ////    ////public void CopyTo(T[] array, int arrayIndex)
    ////    ////{
    ////    ////    throw new NotImplementedException();
    ////    ////}

    ////    ////public bool Remove(T item)
    ////    ////{
    ////    ////    throw new NotImplementedException();
    ////    ////}

    ////    ////int ICollection<T>.Count { get; private set; }
    ////    ////public bool IsReadOnly { get; private set; }
    ////    ////public int IndexOf(U item)
    ////    ////{
    ////    ////    throw new NotImplementedException();
    ////    ////}

    ////    ////public void Insert(int index, U item)
    ////    ////{
    ////    ////    throw new NotImplementedException();
    ////    ////}

    ////    ////void IList<U>.RemoveAt(int index)
    ////    ////{
    ////    ////    throw new NotImplementedException();
    ////    ////}

    ////    ////public int IndexOf(T item)
    ////    ////{
    ////    ////    throw new NotImplementedException();
    ////    ////}

    ////    ////public void Insert(int index, T item)
    ////    ////{
    ////    ////    throw new NotImplementedException();
    ////    ////}

    ////    ////void IList<T>.RemoveAt(int index)
    ////    ////{
    ////    ////    throw new NotImplementedException();
    ////    ////}

    ////    ////T IList<T>.this[int index]
    ////    ////{
    ////    ////    get { throw new NotImplementedException(); }
    ////    ////    set { throw new NotImplementedException(); }
    ////    ////}

    ////    ////public U this[int index]
    ////    ////{
    ////    ////    get { throw new NotImplementedException(); }
    ////    ////    set { throw new NotImplementedException(); }
    ////    ////}

    ////    ////IEnumerator IEnumerable.GetEnumerator()
    ////    ////{
    ////    ////    return GetEnumerator();
    ////    ////}
    ////}
}
