using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace NoffaPlus.ViewModels
{
	public class OperatorQueueListViewModel : BaseViewModel
	{
		#region Constructor.
		public OperatorQueueListViewModel(INavigation navigation)
		{
			Navigation = navigation;
			QueueInfoList = new ObservableCollection<QueueInfo>();
			for (int i = 0; i < 10; i++)
			{
				QueueInfoList.Add(new QueueInfo()
				{
					QueueName = $"Queue name {i}",
					QueueDate = $"2021/09/{i}",
					PostionInLine = $"{i}",
					OperatorAvailable = $"{i}"
				});
			}
			
		}
		#endregion

		#region Properties.
		public ObservableCollection<QueueInfo> QueueInfoList { get; set; }
		#endregion
	}
}

public class QueueInfo
{
	public string QueueName { get; set; }
	public string QueueDate { get; set; }
	public string PostionInLine { get; set; }
	public string OperatorAvailable { get; set; }
	public string FirstLetterName => System.Globalization.StringInfo.GetNextTextElement(QueueName, 0);
}
