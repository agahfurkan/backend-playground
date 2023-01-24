# backend-playground
## Getting Started
- Create a new Mysql database called 'apiplaygrounddb'.
- To create all tables and fill them with data, import apiplaygrounddb.sql.
- Update the credentials in appsettings.json.

## Table Scripts
```sql
BEGIN
    DECLARE i int DEFAULT 1;
    DELETE FROM category;
    DELETE FROM product;
    WHILE i <= 100
        DO
            INSERT INTO category (category_name) VALUES (CONCAT('category', i));
            SELECT LAST_INSERT_ID() into @categoryId;
            BEGIN
                DECLARE x int DEFAULT 1;
                WHILE x <= 1500
                    DO
                        INSERT INTO product (product_name, product_description, price, category_id, discount, picture)
                        VALUES (CONCAT('ProductName', x), CONCAT('ProductDescription', x), x * 25.75, @categoryId,
                                x * 0.15, 'xxx');
                        SET x = x + 1;
                    end while;
            END;

            SET i = i + 1;
        END WHILE;
END
```

```sql 
CREATE TABLE `active_cart` (
 `id` bigint(20) NOT NULL AUTO_INCREMENT,
 `user_id` bigint(20) NOT NULL,
 `product_id` int(11) NOT NULL,
 `product_name` text NOT NULL,
 `product_description` text DEFAULT NULL,
 `price` double DEFAULT NULL,
 `discount` double DEFAULT NULL,
 `picture` text DEFAULT NULL,
 PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4
```
```sql
CREATE TABLE `category` (
 `category_id` int(11) NOT NULL AUTO_INCREMENT,
 `category_name` text NOT NULL,
 PRIMARY KEY (`category_id`),
 UNIQUE KEY `category_category_name_uindex` (`category_name`) USING HASH
) ENGINE=InnoDB AUTO_INCREMENT=3513 DEFAULT CHARSET=utf8mb4
```

```sql
CREATE TABLE `order` (
 `order_id` bigint(20) NOT NULL AUTO_INCREMENT,
 `user_id` bigint(20) NOT NULL,
 `order_date` datetime NOT NULL,
 `product_id` int(11) NOT NULL,
 `order_status_id` int(11) NOT NULL,
 PRIMARY KEY (`order_id`),
 UNIQUE KEY `order_user_id_uindex` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4
```

```sql
CREATE TABLE `order_status` (
 `order_status_id` int(11) NOT NULL AUTO_INCREMENT,
 `status_title` text NOT NULL,
 `status_description` int(11) NOT NULL,
 `order_id` int(11) NOT NULL,
 PRIMARY KEY (`order_status_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4
```
```sql
CREATE TABLE `product` (
 `product_id` int(11) NOT NULL AUTO_INCREMENT,
 `product_name` text NOT NULL,
 `product_description` text NOT NULL,
 `price` double NOT NULL,
 `category_id` int(11) NOT NULL,
 `discount` double DEFAULT NULL,
 `picture` text DEFAULT NULL,
 PRIMARY KEY (`product_id`)
) ENGINE=InnoDB AUTO_INCREMENT=10645502 DEFAULT CHARSET=utf8mb4
```
```sql
CREATE TABLE `user` (
 `user_id` bigint(20) NOT NULL AUTO_INCREMENT,
 `username` text NOT NULL,
 `password` text NOT NULL,
 PRIMARY KEY (`user_id`),
 UNIQUE KEY `user_user_id_uindex` (`user_id`),
 UNIQUE KEY `user_username_uindex` (`username`) USING HASH
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4
```
