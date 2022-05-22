using System;

namespace Vendingmachine_wpf;

public class BottleEventArgs : EventArgs {
	public Bottle Bottle { get; set; }

	public BottleEventArgs(Bottle bottle) {
		Bottle = bottle;
	}
}