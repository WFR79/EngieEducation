/*
 * Created by SharpDevelop.
 * User: HCE339
 * Date: 22-05-2012
 * Time: 15:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace SynapseCore.Entities
{
	/// <summary>
	/// Description of EntityCollection.
	/// </summary>
	public class EntityCollection :CollectionBase
	{
		Hashtable Keys;
		public EntityCollection()
		{
			Keys=new Hashtable();
		}
		public int Add(object item,string key)
		{

			if (!this.Contains(item))
			{
				int idx = List.Add(item);
				Keys.Add(key,idx);
				return idx;
			}
			else
				return 0;
		}
		public void Remove(object item)
		{
			List.Remove(item);
		}
		public bool Contains(object item)
		{
			return List.Contains(item);
		}
		public int IndexOf(object item)
		{
			return List.IndexOf(item);
		}
		public void CopyTo(object[] array, int index)
		{
			List.CopyTo(array, index);
		}
		public object this[int index]
		{
			get { return (object)List[index]; }
			set { List[index] = value; }
		}
	}
}
