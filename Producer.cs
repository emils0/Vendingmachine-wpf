using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Vendingmachine_wpf;

public static class Producer {
	public static readonly Queue<Bottle> BottleList = new();
	private static int _bottleId;

	public static void ProduceBottles() {
		while (true) {
			Thread.Sleep(1000);
			_bottleId++;

			lock (BottleList) {
				BottleList.Enqueue(new Bottle(_bottleId));
			}

			Debug.WriteLine($"The queue contains {BottleList.Count} bottles.");
		}
	}
}