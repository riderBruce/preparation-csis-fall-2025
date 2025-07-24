const customer = {
    id: 1000,
    name: "Sam",
    email: "sam@example.com",
}

const orders = [
    {order_id: 500001, customer_id: 1000, product: "monitor"},
    {order_id: 500002, customer_id: 1000, product: "mouse"},
    {order_id: 500003, customer_id: 1200, product: "HDD"},
]

function getOrderByCustomer(customer) {
    return orders.filter((order) => order.customer_id === customer.id);
}

console.log(getOrderByCustomer(customer))