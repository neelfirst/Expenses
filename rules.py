#!/usr/bin/python

# a programmatically generated script
# that is imported to and run from process

def enum(**enums):
	return type('Enum', (), enums)

# bank of rules - assigns a label to an expense row
Rules = enum (	Food='Food',Rent='Rent',Util='Util',Home='Home',Gear='Gear',Cats='Cats',
		Trans='Trans',Travel='Travel',Health='Health',Fun='Fun',Misc='Misc' )

def getRules():
	list = ''
	list = list + Rules.Food + ","
	list = list + Rules.Rent + ","
	list = list + Rules.Util + ","
	list = list + Rules.Home + ","
	list = list + Rules.Gear + ","
	list = list + Rules.Cats + ","
	list = list + Rules.Trans + ","
	list = list + Rules.Travel + ","
	list = list + Rules.Health + ","
	list = list + Rules.Fun + ","
	list = list + Rules.Misc
	return list

def checkRule(rule):
	if rule == 'Food':
		return True
	if rule == 'Rent':
		return True
	if rule == 'Util':
		return True
	if rule == 'Home':
		return True
	if rule == 'Gear':
		return True
	if rule == 'Cats':
		return True
	if rule == 'Trans':
		return True
	if rule == 'Travel':
		return True
	if rule == 'Health':
		return True
	if rule == 'Fun':
		return True
	if rule == 'Misc':
		return True
	return False

def applyRules(date, desc, cost, category):
	if 'MONTE CRISTO' in desc:
		return Rules.Food
	if 'MONTEREY MARKET' in desc:
		return Rules.Food
	if 'COUNTRY CHEESE' in desc:
		return Rules.Food
	if 'TRADER JOE' in desc:
		return Rules.Food
	if 'Video On Demand' in desc:
		return Rules.Fun
	if 'PET FOOD' in desc:
		return Rules.Cats
	if 'VZWRLSS' in desc:
		return Rules.Util
	if 'EAST BAY NURSERY' in desc:
		return Rules.Home
	if 'MAGNANIS POULTRY' in desc:
		return Rules.Food
	if 'JUPITER' in desc:
		return Rules.Food
	if 'WHOLEFDS BRK 10006' in desc:
		return Rules.Food
	if 'BERKELEY FAMILY DENTAL' in desc:
		return Rules.Health
	if 'SQ *TAQUERIA GIRASOL SFSU' in desc:
		return Rules.Food
	if 'OTGMANAGEMENTTUCSON, LLC' in desc:
		return Rules.Food
	if 'WILKO' in desc:
		return Rules.Food
	if 'EINSTEIN BROS BAGELS1653' in desc:
		return Rules.Food
	if 'PLIA-SABINO CANYON RD' in desc:
		return Rules.Fun
	if 'FASTRAK CSC' in desc:
		return Rules.Trans
	if 'BOBO`S RESTAURANT' in desc:
		return Rules.Food
	if 'BAY READER' in desc:
		return Rules.Misc
	if 'THE BLOC' in desc:
		return Rules.Food
	if 'BEYOND BREAD       QPS' in desc:
		return Rules.Food
	if 'WALGREENS #15025' in desc:
		return Rules.Health
	if 'ROXANNE C FISCELLA MD' in desc:
		return Rules.Health
	if 'TOYO JAPANESE RESTAURANT' in desc:
		return Rules.Food
	if 'INTUIT *TURBOTAX' in desc:
		return Rules.Home
	if 'CHEVRON 00090877' in desc:
		return Rules.Trans
	if 'ALMARE LLC' in desc:
		return Rules.Food
	if 'GIOIA PIZZERIA' in desc:
		return Rules.Food
	if 'AU COQUELET CAFE' in desc:
		return Rules.Food
	if 'SQ *CAFE YESTERDAY' in desc:
		return Rules.Food
	if 'PEGASUS BOOKS' in desc:
		return Rules.Gear
	if 'USPS 05064295523504616' in desc:
		return Rules.Misc
	if 'Amazon Digital Svcs' in desc:
		return Rules.Fun
	if 'PLAYSTATION SONYENTERT' in desc:
		return Rules.Fun
	if 'UNIVERSITY HAIR CARE' in desc:
		return Rules.Misc
	if 'ASI*HUMBLE BUNDLE' in desc:
		return Rules.Fun
	if 'SOUTHWES    5262196482008' in desc:
		return Rules.Travel
	if 'SOUTHWES    5260642172502' in desc:
		return Rules.Travel
	if 'POINT REYES NATIONAL SEAS' in desc:
		return Rules.Fun
	if 'GRAND OAKS RESTAURANT' in desc:
		return Rules.Food
	if 'SOUTHWES    5262195526903' in desc:
		return Rules.Travel
	if 'LAMA BEANS' in desc:
		return Rules.Food
	if 'CI OF BERKELEY SHATTUCK' in desc:
		return Rules.Misc
	if 'SAFEWAY  STORE00006916' in desc:
		return Rules.Food
	if '7-ELEVEN 18855' in desc:
		return Rules.Misc
	if 'REI 12 BERKELEY' in desc:
		return Rules.Gear
	if 'WESTBRAE NURSERY' in desc:
		return Rules.Home
	if 'CAFE PLATANO' in desc:
		return Rules.Food
	if 'SFSU STATION CAFE' in desc:
		return Rules.Food
	if 'SODA POPINSKIS' in desc:
		return Rules.Fun
	if 'SUSHIKO JAPANESE RESTAUR' in desc:
		return Rules.Food
	if 'BERKELEY ACE HDWE' in desc:
		return Rules.Home
	if 'BERKELEY REPERTORY THTR' in desc:
		return Rules.Fun
	if 'SUNNY SIDE CAFE OXFORD ST' in desc:
		return Rules.Food
	if 'PFD*PET360' in desc:
		return Rules.Cats
	if 'RASDASHEN MARKET' in desc:
		return Rules.Food
	if 'RED TOMATOE PIZZA HOUS' in desc:
		return Rules.Fun
	if 'ATHINEON' in desc:
		return Rules.Food
	if 'BANGKOK THAI CUISINE' in desc:
		return Rules.Food
	if 'PIER 23' in desc:
		return Rules.Fun
	if 'THEECONOMIST NEWSPAPER' in desc:
		return Rules.Gear
	if 'HALF PRICE BOOKS #037' in desc:
		return Rules.Gear
	if 'HA TIEN COVE' in desc:
		return Rules.Food
	if 'TMS*SHAHJERD MANAGEMEN' in desc:
		return Rules.Food
	if 'STATE OF CALIF DMV INT SC' in desc:
		return Rules.Trans
	if 'LIBRARY GARDENS 81238' in desc:
		return Rules.Food
	if 'ACT*East Bay Reg Parks' in desc:
		return Rules.Fun
	if 'UNIVERSITY VALERO' in desc:
		return Rules.Trans
	if 'ANIMAL FARM' in desc:
		return Rules.Home
	if 'LA MISSION' in desc:
		return Rules.Food
	if 'SQ *TAQUERIA GIRASOL' in desc:
		return Rules.Food
	if 'CVS PHARMACY #3026' in desc:
		return Rules.Health
	if 'SQ *THE SANDWICH SPOT, BE' in desc:
		return Rules.Food
	if 'PJRC.COM, LLC' in desc:
		return Rules.Misc
	if 'NORIEGA PRODUCE' in desc:
		return Rules.Food
	if 'ORDERS@GOODEGGS.COM' in desc:
		return Rules.Food
	if 'ALIVE AND WELL NATURAL HE' in desc:
		return Rules.Food
	if 'MAUI SEASIDE HOTEL' in desc:
		return Rules.Travel
	if 'SHELL OIL 57444727101' in desc:
		return Rules.Travel
	if 'ENTERPRISE RENT-A-CAR' in desc:
		return Rules.Travel
	if 'STILLWELLS BAKERY' in desc:
		return Rules.Food
	if 'DA KITCHEN EXPRESS' in desc:
		return Rules.Food
	if 'LAVA JAVA COFFEE ROAST' in desc:
		return Rules.Food
	if 'SAFEWAY  STORE00012229' in desc:
		return Rules.Food
	if 'PWF ECO ADVENTURES' in desc:
		return Rules.Travel
	if 'MAUI DIVE SHOP' in desc:
		return Rules.Travel
	if 'BANGKOK CUISINE' in desc:
		return Rules.Food
	if 'KMART 7488' in desc:
		return Rules.Gear
	if 'HALAC CORPORATION DBA' in desc:
		return Rules.Food
	if 'ORCHARD SUPPLY #470' in desc:
		return Rules.Home
	if 'THE HOME DEPOT 627' in desc:
		return Rules.Home
	if 'CAFE LEILA' in desc:
		return Rules.Food
	if '7 DAYS A WEEK SMOG' in desc:
		return Rules.Trans
	if 'PATTIS AUTO CARE' in desc:
		return Rules.Trans
	if 'EB GAMES #4887' in desc:
		return Rules.Fun
	if 'LUCKY HOUSE THAI' in desc:
		return Rules.Food
	if 'TFI*TICKETFLY EVENTS' in desc:
		return Rules.Fun
	if 'STARBUCKS 11746 ONTARIO' in desc:
		return Rules.Food
	if 'WAL-MART 1992' in desc:
		return Rules.Misc
	if 'MCDONALDS F17505' in desc:
		return Rules.Food
	if 'MANDARIN GARDEN' in desc:
		return Rules.Food
	if 'QUICK GAS VALERO' in desc:
		return Rules.Trans
	if 'ALAMO RENT-A-CAR' in desc:
		return Rules.Travel
	if 'FRSTGVG*LAKEBAIKALHERITAG' in desc:
		return Rules.Misc
	if 'MESOB ETHIOPIAN RESTAURA' in desc:
		return Rules.Food
	if 'JAYAKARTA RESTAURANT' in desc:
		return Rules.Food
	if 'FELLINI COFFEE BAR' in desc:
		return Rules.Fun
	if 'ANGELINES LOUISIA' in desc:
		return Rules.Food
	if 'BERONIO LUMBER STORE 1' in desc:
		return Rules.Home
	if 'WPY*Honeyfund 855-469-3729 VA' in desc:
		return Rules.Misc
	if 'PIZZA MODA' in desc:
		return Rules.Food
	if 'FLOAT' in desc:
		return Rules.Fun
	if 'BEAST AND THE HARE' in desc:
		return Rules.Food
	if 'PBW RPP PERMITS 866-226-9288 CA' in desc:
		return Rules.Trans
	if 'LEDGERS LIQUORS' in desc:
		return Rules.Fun
	if 'AL LASHERS ELECTRONICS' in desc:
		return Rules.Misc
	if 'VIKS CHAAT CORNER' in desc:
		return Rules.Food
	if 'VIKS MARKET CORNER' in desc:
		return Rules.Food
	if 'ASI*KICKSTARTER COM 866-749-7545 WA' in desc:
		return Rules.Fun
	if 'TRIPLE ROCK BREWERY' in desc:
		return Rules.Food
	if 'CHIPOTLE 0231' in desc:
		return Rules.Food
	if 'ASHBY LUMBER' in desc:
		return Rules.Home
	if 'AIRBNB INC 415-800-5959 CA' in desc:
		return Rules.Travel
	if 'BETA LOUNGE' in desc:
		return Rules.Fun
	if 'EL RANCHO MARKET MENLO PARK CA' in desc:
		return Rules.Food
	if 'PLN*PRICELINE RENTAL 888-837-3774 CT' in desc:
		return Rules.Travel
	if 'BART-COLISEUM QPS 5104646979 CA' in desc:
		return Rules.Travel
	if 'HAMPTON INNS OMAHA NE' in desc:
		return Rules.Travel
	if 'THE OLD MATTRESS FACTORY OMAHA NE' in desc:
		return Rules.Food
	if 'PLEARN THAI RESTAURANT' in desc:
		return Rules.Food
	if 'PASTA SHOP 4TH ST' in desc:
		return Rules.Food
	if 'MIDDLE EAST MARKET' in desc:
		return Rules.Food
	if 'SOUTHWES 5262427067629 800-435-9792 TX' in desc:
		return Rules.Travel
	if 'CITY OF BERKELEY- IPS' in desc:
		return Rules.Trans
	if 'BERKELEY PHYSICAL THERAP' in desc:
		return Rules.Health
	if 'OAK INTL  ARPRT' in desc:
		return Rules.Travel
	if 'HEB #630' in desc:
		return Rules.Food
	if 'COLDSTONE #1131' in desc:
		return Rules.Food
	if 'BOBBY GS PIZZERIA' in desc:
		return Rules.Food
	if 'PI Q' in desc:
		return Rules.Food
	if 'HOPKINS STREET PIZZA' in desc:
		return Rules.Food
	if 'KIRALA' in desc:
		return Rules.Food
	if 'KIMS CAFE & SANDWICH' in desc:
		return Rules.Food
	if 'HOME OF CHICKEN AND WAFF' in desc:
		return Rules.Food
	if 'THE MISSING LINK' in desc:
		return Rules.Trans
	if 'RED ROCK CAF / BACKD' in desc:
		return Rules.Food
	if 'IKEA EAST BAY' in desc:
		return Rules.Home
	if 'HERTZ RENT-A-CAR' in desc:
		return Rules.Travel
	if 'BART-BERKELEY      QPS' in desc:
		return Rules.Travel
	if 'BALD EAGLE COFFEE HOUSE' in desc:
		return Rules.Food
	if 'MARINER MARKET' in desc:
		return Rules.Food
	if 'WRIGHTS FOR CAMPING' in desc:
		return Rules.Travel
	if 'SAFEWAY  STORE00012302' in desc:
		return Rules.Food
	if 'BART-COLISEUM      QPS' in desc:
		return Rules.Travel
	if 'AXS TIX-SHOWBOX' in desc:
		return Rules.Fun
	if 'CLIPPER SERVICE' in desc:
		return Rules.Trans
	if 'AM CANCER SOC CV' in desc:
		return Rules.Misc
	if 'MONTEREY FISH MKT' in desc:
		return Rules.Food
	if 'BONITA FISH MARKET' in desc:
		return Rules.Food
	if 'KIKU SUSHI' in desc:
		return Rules.Food
	if 'AmazonPrime Membership' in desc:
		return Rules.Misc
	if 'Republic of V' in desc:
		return Rules.Food
	if 'CHEVRON 00207352' in desc:
		return Rules.Trans
	if 'CRATER LAKE CAMPGROUND' in desc:
		return Rules.Travel
	if 'ROCKY POINT RV RESORT' in desc:
		return Rules.Travel
	if 'NIBBLEYS CAFE' in desc:
		return Rules.Food
	if 'CRATER LAKE NATURAL HIST' in desc:
		return Rules.Travel
	if 'CRATER LAKE NP-NORTH ES' in desc:
		return Rules.Travel
	if 'LAVA LAKE LODGE' in desc:
		return Rules.Travel
	if 'MWA REFUGE GIFT SHOP' in desc:
		return Rules.Travel
	if 'DESCHUTES BREWERY' in desc:
		return Rules.Fun
	if 'SAFEWAY  STORE00018887' in desc:
		return Rules.Food
	if 'SHELL OIL 57445918105' in desc:
		return Rules.Travel
	if 'THE HIGH DESERT MUSEUM' in desc:
		return Rules.Travel
	if 'CHEVRON 00099270' in desc:
		return Rules.Travel
	if 'AAA MEMBERSHIP' in desc:
		return Rules.Travel
	if 'CAMPUS VETERINARY CLINIC' in desc:
		return Rules.Cats
	if 'BERKELEY REP BOX OFFICE' in desc:
		return Rules.Fun
	if 'NINE THAI EATERY' in desc:
		return Rules.Food
	if 'BUILD PIZZERIA ROM' in desc:
		return Rules.Food
	if 'CALIFORNIA THEATRE 204' in desc:
		return Rules.Fun
	if 'CALIFOR CINEMA WEB 204' in desc:
		return Rules.Fun
	if 'GAMES OF BERKELEY' in desc:
		return Rules.Fun
	if 'OUT OF THE CLOSET' in desc:
		return Rules.Gear
	if 'SIMPLY GREEK' in desc:
		return Rules.Food
	if 'STEAMPOWERED.COM' in desc:
		return Rules.Fun
	if 'NEXUSMODS' in desc:
		return Rules.Fun
	if 'TM *TYCHO' in desc:
		return Rules.Fun
	if 'FIREWOOD CAFE OAKLAND' in desc:
		return Rules.Food
	if 'RAMEN YAMADAYA' in desc:
		return Rules.Food
	if 'BERKELEY ENDOCRINE CLINIC' in desc:
		return Rules.Health
	if 'AmazonLocal' in desc:
		return Rules.Misc
	if 'JOYFUL HOUSE EXPRESS' in desc:
		return Rules.Food
	if 'Canon imageCLASS LBP6000 Compact Laser Printer' in desc:
		return Rules.Gear
	if 'Now Foods Organic Whey Protein, 1 Pound' in desc:
		return Rules.Food
	if 'Precious Cat Respiratory Releif Clay Premium all Natual Cat Litter with Herbal Essences' in desc:
		return Rules.Cats
	if 'Litter Genie 3-Pack Standard Refill for Litter Box' in desc:
		return Rules.Cats
	if 'Agricola World Championship Deck Expansion' in desc:
		return Rules.Fun
	if 'Valkyria Chronicles - Playstation 3' in desc:
		return Rules.Fun
	if 'Anker Astro Mini 3000mAh Ultra-Compact Portable Charger Lipstick-Sized External Battery Power Bank Pack for most Smartphones and other USB-charged dev' in desc:
		return Rules.Gear
	if 'eneloop NEW 800 mAh Typical, 750 mAh Minimum, 1500 cycle, 4 pack AAA, Ni-MH Pre-Charged Rechargeable Batteries' in desc:
		return Rules.Gear
	if 'The Thing with Feathers: The Surprising Lives of Birds and What They Reveal About Being Human' in desc:
		return Rules.Gear
	if 'Sedona Labs Iflora Nasal Health Capsules, 90-Count' in desc:
		return Rules.Health
	if 'Hoover SteamVac Carpet Washer with Clean Surge, F5914900' in desc:
		return Rules.Home
	if 'The Science of Good Cooking (Cooks Illustrated Cookbooks)' in desc:
		return Rules.Gear
	if 'Bose SoundLink Mini Bluetooth Speaker' in desc:
		return Rules.Gear
	if 'Puzzles to Puzzle You' in desc:
		return Rules.Gear
	if 'A River Lost: The Life and Death of the Columbia (Revised and Updated)' in desc:
		return Rules.Gear
	if 'Water Matters: Why We Need to Act Now to Save Our Most Critical Resource' in desc:
		return Rules.Gear
	if 'Introduction to Water in California (California Natural History Guides)' in desc:
		return Rules.Gear
	if 'Rat Island: Predators in Paradise and the Worlds Greatest Wildlife Rescue' in desc:
		return Rules.Gear
	if 'Avatar: The Last Airbender, The Search' in desc:
		return Rules.Gear
	if 'Celestron 71330 Nature DX 8x32 Binocular (Army Green)' in desc:
		return Rules.Gear
	if 'Trademark Games 9 Piece Bocce Ball Set with Easy Carry Nylon Case' in desc:
		return Rules.Gear
	if 'Dunlop Play Smash 4 Player Badminton Set' in desc:
		return Rules.Gear
	if 'Mavis 2000 Nylon Tournament Shuttle-Yellow (1/2 dozen)' in desc:
		return Rules.Gear
	if 'OXO Good Grips Dustpan and Brush Set' in desc:
		return Rules.Home
	if 'Hearos Ultimate Softness Series Foam Earplugs, 20-Pair' in desc:
		return Rules.Misc
	if '$50 PlayStation Store Gift Card - PS3/ PS4/ PS Vita [Digital Code]' in desc:
		return Rules.Fun
	if 'Del Rossa Mens Fleece Full Length Shawl Collar Bathrobe Robe, Small Medium Blue on White Plaid (A0124P06MD)' in desc:
		return Rules.Gear
	if 'Now Foods Organic Whey Protein, Natural Unflavored 1 Pound' in desc:
		return Rules.Food
	if 'Kinivo BTH240 Bluetooth Stereo Headphone - Supports Wireless Music Streaming and Hands-Free calling (Black)' in desc:
		return Rules.Gear
	if 'Optoma HD65 Projector Brand New High Quality Original Projector Bulb' in desc:
		return Rules.Gear
	if 'KV Economical Full Extension Drawer Slide 28" 100lb Load Rating (1 set)' in desc:
		return Rules.Misc
	if 'Mod Podge CS11220 8-Ounce Glue, Outdoor' in desc:
		return Rules.Home
	if 'COMMAND Wire Hooks, 18 Pieces, Indoor White, Holds .5 Lbs.' in desc:
		return Rules.Home
	if 'Pinnacle 11FW1445 Natural 7-Piece Solid Wood Wall Frame Kit' in desc:
		return Rules.Home
	if 'Stack-On SBR-18 17 Compartment Parts Storage Organizer Box with Removable Dividers, Red' in desc:
		return Rules.Home
	if 'BISSELL Natural Sweep Dual Brush Sweeper, 92N0A (same as 92N0)' in desc:
		return Rules.Home
	if 'Planet Bike The Dial Guage Analog Bicycle Tire Gauge (0-140psi)' in desc:
		return Rules.Trans
	if 'Stack-On PR-19 19-Inch Pro Tool Box, Black/Red' in desc:
		return Rules.Home
	if 'Cyclokraft Mini Bike Pump - Portable & Lightweight - Dual Action Air Inflation - 60 Day Moneyback Guarantee - High Pressure & Pocket Size - Works with' in desc:
		return Rules.Trans
	if 'Marineland PA0373 Black Diamond Activated Carbon, 40-Ounce, 1134-Gram' in desc:
		return Rules.Cats
	if 'Jarrow Formulas CDP Choline 250mg, 60 Capsules' in desc:
		return Rules.Health
	if 'KitchenAid KSM75WH 4.5-Quart Classic Plus Stand Mixer, White' in desc:
		return Rules.Home
	if 'Vivobarefoot Womens One L Running Shoe,Sulphur/Purple,37 EU/7 M US' in desc:
		return Rules.Gear
	if 'Basiloff Cheesecloth 4.8 Sq Yds Chef Grade Fine Mesh Unbleached 100% Cotton' in desc:
		return Rules.Home
	if 'Wireless PS3 Controller To PC USB Adapter [Mayflash]' in desc:
		return Rules.Fun
	if 'Pirate Satin Eye Patch Halloween Costume Accessory' in desc:
		return Rules.Fun
	if 'Del Rossa Womens Fleece Full Length Shawl Collar Bathrobe Robe, Small Medium Purple and Teal Plaid (A0124P05MD)' in desc:
		return Rules.Gear
	if '100ct Lot - Metal Pipe Screens (3/4") (.750") (BRASS)' in desc:
		return Rules.Misc
	if 'Miele S2121 Olympus Canister Vacuum Cleaner' in desc:
		return Rules.Home
	return 'none'
