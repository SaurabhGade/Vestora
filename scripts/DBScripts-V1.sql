-- Active: 1786867450645@@127.0.0.1@5432@vestora
INSERT INTO
  "COM_CONFIGSETTINGS" (
    "CONFIG_KEY",
    "CONFIG_VALUE",
    "CONFIG_TYPE",
    "DESCRIPTION",
    "IS_ACTIVE",
    "CREATED_BY",
    "CREATED_DATE",
    "MODIFIED_BY",
    "MODIFIED_DATE"
  )
VALUES
  (
    'MENU_MARKET',
    '{"name":"Market","route":"/market","icon":"market","displayOrder":2}',
    'MENU',
    'Market',
    TRUE,
    1,
    NOW (),
    1,
    NOW ()
  ),
  (
    'MENU_IPO',
    '{"name":"IPOs","route":"/ipo","icon":"ipo","displayOrder":3}',
    'MENU_IPO',
    'IPO management',
    TRUE,
    1,
    NOW (),
    1,
    NOW ()
  ),
  (
    'MENU_WATCHLIST',
    '{"name":"Watchlist","route":"/watchlist","icon":"watchlist","displayOrder":4}',
    'MENU',
    'Stock watchlist',
    TRUE,
    1,
    NOW (),
    1,
    NOW ()
  ),
  (
    'MENU_PORTFOLIO',
    '{"name":"Portfolio","route":"/portfolio","icon":"portfolio","displayOrder":5}',
    'MENU',
    'Investment portfolio',
    TRUE,
    1,
    NOW (),
    1,
    NOW ()
  ),
  (
    'MENU_RISK',
    '{"name":"Risk","route":"/risk","icon":"risk","displayOrder":6}',
    'MENU',
    'Investment risk analysis',
    TRUE,
    1,
    NOW (),
    1,
    NOW ()
  );

INSERT INTO
  "SEC_SECURITY" (
    "SYMBOL",
    "COMPANY_NAME",
    "ISIN",
    "EXCHANGE",
    "SECURITY_TYPE",
    "SECTOR",
    "INDUSTRY",
    "IS_ACTIVE",
    "CREATED_DATE"
  )
VALUES
  (
    'RELIANCE',
    'Reliance Industries Ltd',
    'INE002A01018',
    'NSE',
    'EQUITY',
    'Energy',
    'Oil & Gas',
    TRUE,
    CURRENT_TIMESTAMP
  ),
  (
    'TCS',
    'Tata Consultancy Services Ltd',
    'INE467B01029',
    'NSE',
    'EQUITY',
    'Information Technology',
    'IT Services',
    TRUE,
    CURRENT_TIMESTAMP
  ),
  (
    'INFY',
    'Infosys Ltd',
    'INE009A01021',
    'NSE',
    'EQUITY',
    'Information Technology',
    'IT Services',
    TRUE,
    CURRENT_TIMESTAMP
  ),
  (
    'HDFCBANK',
    'HDFC Bank Ltd',
    'INE040A01034',
    'NSE',
    'EQUITY',
    'Financial Services',
    'Banks',
    TRUE,
    CURRENT_TIMESTAMP
  ),
  (
    'ICICIBANK',
    'ICICI Bank Ltd',
    'INE090A01021',
    'NSE',
    'EQUITY',
    'Financial Services',
    'Banks',
    TRUE,
    CURRENT_TIMESTAMP
  );

INSERT INTO
  "SEC_MARKET_DATA" (
    "SECURITY_ID",
    "TRADE_DATE",
    "OPEN_PRICE",
    "HIGH_PRICE",
    "LOW_PRICE",
    "CLOSE_PRICE",
    "ADJUSTED_CLOSE_PRICE",
    "PREVIOUS_CLOSE_PRICE",
    "VOLUME",
    "VALUE_TRADED",
    "CHANGE_VALUE",
    "CHANGE_PERCENT"
  )
VALUES
  (
    1,
    '2026-08-24',
    1450.00,
    1475.00,
    1440.00,
    1468.50,
    1468.50,
    1449.00,
    12500000,
    18356250000,
    19.50,
    1.346
  ),
  (
    1,
    '2026-08-25',
    1469.00,
    1482.00,
    1458.00,
    1477.25,
    1477.25,
    1468.50,
    13200000,
    19499700000,
    8.75,
    0.596
  ),
  (
    1,
    '2026-08-26',
    1478.00,
    1495.00,
    1470.00,
    1491.80,
    1491.80,
    1477.25,
    14100000,
    209232990,
    14.55,
    0.985
  );