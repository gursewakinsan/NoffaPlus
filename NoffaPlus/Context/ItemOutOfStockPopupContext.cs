using System;

namespace NoffaPlus
{
	public class ItemOutOfStockPopupContext
	{
		public Action CallBack { get; set; }
		public int AvailableDishId { get; set; }
	}
}
