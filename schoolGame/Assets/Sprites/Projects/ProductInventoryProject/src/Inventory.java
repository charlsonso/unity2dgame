import java.util.LinkedList;

public class Inventory {
	LinkedList<Product> product;

	public Inventory() {
		this.product = new LinkedList<Product>();
	}
	public Product getProduct(int index) {
		return product.get(index);
	}

	public void setProduct(Product prod) {
		this.product.add(prod);
	}
	public void removeProduct(String id) {
		boolean checker = false;
		System.out.println("");
		for(int i = 0; i < this.product.size() && checker != true; i ++) {
			if (this.product.get(i).getID().equals(id.trim())) {
				this.product.remove(i);
				System.out.println("Success.\n");
				checker = true;
			} 
		}
		if (checker == false) {
			System.out.println("There is no product of this ID.\n");
		}
	}
	public void displayAll () {
		System.out.println("\n| |||||||||||||||||||||||||||||||||||||||| |");
		System.out.println("| ----------------PRODUCTS---------------- |"); 
		if( product.size() == 0) {
			System.out.print("There are no products currently listed.");
		}
		for(int i = 0 ; i < product.size(); i++) {
			System.out.println("\t\tID: " + product.get(i).getID());
			System.out.println("\t\tPrice: " + product.get(i).getPrice());
			System.out.println("\t\tQuantity: " + product.get(i).getQuantity());
			System.out.println("|  --------------------------------------- |");

		}
		System.out.println("\n| |||||||||||||||||||||||||||||||||||||||| |\n");

	}
	
}
