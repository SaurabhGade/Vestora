-- Active: 1786867450645@@127.0.0.1@5432@vestora

INSERT INTO "COM_CONFIGSETTINGS"
("CONFIG_KEY","CONFIG_VALUE","CONFIG_TYPE","DESCRIPTION","IS_ACTIVE", "CREATED_BY", "CREATED_DATE", "MODIFIED_BY", "MODIFIED_DATE")
VALUES
('MENU_MARKETS','{"name":"Markets","route":"/markets","icon":"markets","displayOrder":2}','MENU','Markets',TRUE, 1, NOW(), 1, NOW()),
('MENU_IPO','{"name":"IPOs","route":"/ipo","icon":"ipo","displayOrder":3}','MENU_IPO','IPO management',TRUE, 1, NOW(), 1, NOW()),
('MENU_WATCHLIST','{"name":"Watchlist","route":"/watchlist","icon":"watchlist","displayOrder":4}','MENU','Stock watchlist',TRUE, 1, NOW(), 1, NOW()),
('MENU_PORTFOLIO','{"name":"Portfolio","route":"/portfolio","icon":"portfolio","displayOrder":5}','MENU','Investment portfolio',TRUE, 1, NOW(), 1, NOW()),
('MENU_RISK','{"name":"Risk","route":"/risk","icon":"risk","displayOrder":6}','MENU','Investment risk analysis',TRUE, 1, NOW(), 1, NOW());


INSERT INTO "SEC_SECURITY"
( "SYMBOL", "COMPANY_NAME", "ISIN", "EXCHANGE", "SECURITY_TYPE", "SECTOR", "INDUSTRY", "IS_ACTIVE", "CREATED_DATE")
VALUES
( 'RELIANCE', 'Reliance Industries Ltd', 'INE002A01018', 'NSE', 'EQUITY', 'Energy', 'Oil & Gas', TRUE, CURRENT_TIMESTAMP),
( 'TCS', 'Tata Consultancy Services Ltd', 'INE467B01029', 'NSE', 'EQUITY', 'Information Technology', 'IT Services', TRUE, CURRENT_TIMESTAMP),
( 'INFY', 'Infosys Ltd', 'INE009A01021', 'NSE', 'EQUITY', 'Information Technology', 'IT Services', TRUE, CURRENT_TIMESTAMP),
( 'HDFCBANK', 'HDFC Bank Ltd', 'INE040A01034', 'NSE', 'EQUITY', 'Financial Services', 'Banks', TRUE, CURRENT_TIMESTAMP),
( 'ICICIBANK', 'ICICI Bank Ltd', 'INE090A01021', 'NSE', 'EQUITY', 'Financial Services', 'Banks', TRUE, CURRENT_TIMESTAMP);



select * from "SEC_SECURITY";