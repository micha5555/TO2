Feature: Operations with Cart Products

@Client @RemoveProductFromCart @ProductInCart
Scenario: Client can remove product from cart
    Given Client is logged in
    And Product is in cart
    When Client removes product from cart
    Then Cart does not contain product 

@Client @RemoveProductFromCart @ProductNotInCart
Scenario: Client cannot remove product from cart
    Given Client is logged in
    And Product is not in cart
    When Client removes product from cart
    Then Cart does not contain product

@Client @AddProductToCart @ProductInCart
Scenario: Client can increase quantity of product from cart
    Given Client is logged in
    And Product is in cart
    And Product quantity is bigger than one
    When Client adds product to cart
    Then Product quantity in cart is increased

@Client @AddProductToCart @SingleItem
Scenario: Client can add single item to cart
    Given Client is logged in
    And Product quantity is one
    When Client adds product to cart
    Then Product is in cart

@Client @AddProductToCart @MultipleItems
Scenario: Client can add multiple items to cart
    Given Client is logged in
    And Product quantity is bigger than one
    When Client adds products to cart
    Then Products are in cart

