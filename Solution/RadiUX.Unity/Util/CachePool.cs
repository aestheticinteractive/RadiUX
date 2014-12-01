using System.Collections.Generic;
using System.Linq;

namespace RadiUX.Unity.Util {

	/*================================================================================================*/
	public class CachePool<T> {

		public delegate T CreatePoolItem(int pId);
		public delegate void ActivatePoolItem(T pItem, bool pActive);

		private readonly IList<T> vCache;
		private readonly string vName;
		private readonly CreatePoolItem vCreateItem;
		private readonly ActivatePoolItem vActivateItem;

		private int vSize;
		private T[] vArray;


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public CachePool(string pName, CreatePoolItem pCreateItem, ActivatePoolItem pActivateItem) {
			vCache = new List<T>();
			vName = pName;
			vCreateItem = pCreateItem;
			vActivateItem = pActivateItem;
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public T[] GetItems() {
			return vArray;
		}
		
		/*--------------------------------------------------------------------------------------------*/
		public int GetLatestSize() {
			return vSize;
		}

		/*--------------------------------------------------------------------------------------------*/
		public void Resize(int pSize) {
			if ( pSize == vSize ) {
				return;
			}

			vSize = pSize;

			while ( vCache.Count < pSize ) {
				T item = vCreateItem(vCache.Count);
				vCache.Add(item);
			}

			for ( int i = 0 ; i < vCache.Count ; ++i ) {
				vActivateItem(vCache[i], (i < pSize));
			}

			vArray = vCache.ToArray();
		}

	}

}
