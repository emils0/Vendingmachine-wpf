using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Vendingmachine_wpf;

public static class Splitter {
	public static readonly Queue<Soda> SodaList = new();
	public static readonly Queue<Beer> BeerList = new();

	public static void StartSplitter() {
		while (true) {
			if (Producer.BottleList.Count != 0) {
				switch (Random.Shared.Next(0, 2)) {
					case 0:
						SodaList.Enqueue(new Soda(Producer.BottleList.Peek().BottleId));
						Debug.WriteLine($"There are now {SodaList.Count} sodas left.");
						break;

					case 1:
						BeerList.Enqueue(new Beer(Producer.BottleList.Peek().BottleId));
						Debug.WriteLine($"There are now {BeerList.Count} beers left.");
						break;
				}

				lock (Producer.BottleList) {
					Producer.BottleList.Dequeue();
				}
			}

			Thread.Sleep(1200);
		}
	}
}