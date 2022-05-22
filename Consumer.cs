using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Vendingmachine_wpf;

public static class Consumer {
	public static event EventHandler<Queue<Beer>> BeerEvent;

	public static void ConsumeBeer() {
		while (true) {
			Thread.Sleep(Random.Shared.Next(500, 5500));

			if (Splitter.BeerList.Count != 0)
				lock (Splitter.BeerList) {
					Debug.WriteLine($"Beer number {Splitter.BeerList.Peek().BottleId} has been consumed.");
					Splitter.BeerList.Dequeue();
				}
			else
				Debug.WriteLine("Attempted to consume beer, but there is no beer left. :(");
		}
	}

	public static void ConsumeSoda() {
		while (true) {
			Thread.Sleep(Random.Shared.Next(500, 5500));

			if (Splitter.SodaList.Count != 0)
				lock (Splitter.SodaList) {
					Debug.WriteLine($"Soda number {Splitter.SodaList.Peek().BottleId} has been consumed.");
					Splitter.SodaList.Dequeue();
				}
			else
				Debug.WriteLine("Attempted to consume soda, but there is no soda left. :(");
		}
	}
}