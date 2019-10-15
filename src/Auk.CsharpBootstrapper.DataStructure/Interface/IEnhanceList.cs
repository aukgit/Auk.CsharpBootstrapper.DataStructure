using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auk.CsharpBootstrapper.DataStructure.Interface
{
    /// <summary>
    /// <see cref="http://bit.ly/31KuASY" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEnhanceList<T> : IList<T>, IParallelProcessor<IEnhanceList<T>, T>
    {
        int PerArrayCapacity { get; set; }

        int Capacity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        bool IsReadOnly { get; set; }

        T[] CreateArray();

       HashSet<T> CreateHashset();

        LinkedList<T> CreateLinkedList();

        bool IsEnableLocking { get; set; }

        
    }

    public class EnhanceList<T> : IEnhanceList<T>
    {
        private IList<T[]> _rawList;
        /// <summary>
        /// 
        /// </summary>
        private long _lastPointingIndex = -1;
        /// <summary>
        /// 
        /// </summary>
        private long _currentArrayPointingIndex = -1;

        /// <summary>
        /// By default <see cref="PerArrayCapacity"/> is 200
        /// </summary>
        public EnhanceList() : this(200)
        {
        }

        public EnhanceList(int perArrayCapacity, bool isAsync = false)
        {
            PerArrayCapacity = perArrayCapacity;
            _rawList = new List<T[]>(1);
            CreateNewRawItem();
        }

        private void CreateNewRawItem()
        {
            _rawList.Add(CreateNewArray());
            Capacity += PerArrayCapacity;
        }

        private T[] CreateNewArray()
        {
            return new T[PerArrayCapacity];
        }

        #region Implementation of IEnumerable

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator() => throw new NotImplementedException();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        #region Implementation of ICollection<T>

        /// <inheritdoc />
        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Clear()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool Contains(T item) => throw new NotImplementedException();

        /// <inheritdoc />
        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool Remove(T item) => throw new NotImplementedException();

        /// <inheritdoc />
        public int Count { get; }

        /// <inheritdoc />
        public bool IsReadOnly { get; set; }

        /// <inheritdoc />
        public T[] CreateArray() => throw new NotImplementedException();

        /// <inheritdoc />
        public HashSet<T> CreateHashset() => throw new NotImplementedException();

        /// <inheritdoc />
        public LinkedList<T> CreateLinkedList() => throw new NotImplementedException();

        /// <inheritdoc />
        public bool IsEnableLocking { get; set; }

        #endregion

        #region Implementation of IList<T>

        /// <inheritdoc />
        public int IndexOf(T item) => throw new NotImplementedException();

        /// <inheritdoc />
        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public T this[int index]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IParallelProcessor<IEnhanceList<T>,T>

        /// <inheritdoc />
        public void ParallelFor(
            IEnhanceList<T> list,
            Action<T> action,
            string functionName)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public IList<TResult> ParallelFor<TResult>(
            IEnhanceList<T> list,
            Func<T, TResult> func,
            string functionName) =>
            throw new NotImplementedException();

        #endregion

        #region Implementation of IEnhanceList<T>

        /// <inheritdoc />
        public int PerArrayCapacity { get; set; }

        /// <inheritdoc />
        public int Capacity { get; set; }

        #endregion
    }

    public interface IParallelProcessor<TListType, TArgument>
    {
        IList<TResult> ParallelFor<TResult>(TListType list, Func<TArgument, TResult> func, string functionName);

        void ParallelFor(TListType list, Action<TArgument> action, string functionName);
    }



    /*
       
     *IResult -> Index, TResult, T
     */
}
