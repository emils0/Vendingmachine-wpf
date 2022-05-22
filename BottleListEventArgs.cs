using System.Collections.Generic;

namespace Vendingmachine_wpf;

public class BottleListEventArgs {
	public Queue<Bottle> BottleList { get; set; }

	public BottleListEventArgs(Queue<Bottle> bottleList) {
		BottleList = bottleList;
	}
}