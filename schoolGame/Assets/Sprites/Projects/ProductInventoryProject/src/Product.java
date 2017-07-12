
public class Product {
	String price = "";
	String ID = "";
	int quantity = 0;
	public Product(String id, String price, int quant) {
		this.ID = id;
		this.price = price;
		this.quantity = quant;
	}
	public String getPrice() {
		return price;
	}
	public void setPrice(String price) {
		this.price = price;
	}
	public String getID() {
		return ID;
	}
	public void setID(String iD) {
		ID = iD;
	}
	public int getQuantity() {
		return quantity;
	}
	public void setQuantity(int quantity) {
		this.quantity = quantity;
	}
	
}
