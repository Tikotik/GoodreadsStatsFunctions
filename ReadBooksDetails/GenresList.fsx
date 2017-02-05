let goodreadsGenres = 
    [|
        "10th-century"
        "11th-century"
        "12th-century"
        "13th-century"
        "14th-century"
        "15th-century"
        "16th-century"
        "17th-century"
        "18th-century"
        "1917"
        "19th-century"
        "1st-grade"
        "20th-century"
        "21st-century"
        "2nd-grade"
        "40k"
        "abuse"
        "academia"
        "academic"
        "academics"
        "accounting"
        "action"
        "activism"
        "adaptations"
        "adolescence"
        "adoption"
        "adult"
        "adult-fiction"
        "adventure"
        "adventurers"
        "africa"
        "african-american"
        "african-american-literature"
        "african-american-romance"
        "african-literature"
        "agriculture"
        "albanian-literature"
        "alchemy"
        "alcohol"
        "algorithms"
        "aliens"
        "alternate-history"
        "alternate-universe"
        "alternative-medicine"
        "amateur-sleuth"
        "amazon"
        "ambulance-service"
        "ambulances"
        "american"
        "american-civil-war"
        "american-classics"
        "american-fiction"
        "american-history"
        "american-novels"
        "americana"
        "amish"
        "amish-fiction"
        "amish-historical-romance-fiction"
        "ancient"
        "ancient-history"
        "angels"
        "anglo-saxon"
        "angola"
        "animal-fiction"
        "animals"
        "anime"
        "anthologies"
        "anthropology"
        "anthropomorphic"
        "anti-racist"
        "antietam-campaign"
        "antiquities"
        "apocalyptic"
        "apple"
        "archaeology"
        "architecture"
        "army-of-tennessee"
        "army-of-the-potomac"
        "art"
        "art-and-photography"
        "art-books-monographs"
        "art-design"
        "art-history"
        "arthurian"
        "artificial-intelligence"
        "asia"
        "asian-literature"
        "aspergers"
        "astrology"
        "astronomy"
        "atheism"
        "australia"
        "autobiography"
        "azeroth"
        "babylon-5"
        "back-to-school"
        "baha-i"
        "bande-dessin%C3%A9e"
        "bangladesh"
        "banking"
        "banks"
        "banned-books"
        "barter"
        "baseball"
        "basketball"
        "batman"
        "battle-of-gettysburg"
        "bdsm"
        "beading"
        "beauty-and-the-beast"
        "beer"
        "belgian"
        "belgium"
        "belief"
        "beverages"
        "biblical"
        "biblical-fiction"
        "bicycles"
        "biography"
        "biography-memoir"
        "biology"
        "bird-watching"
        "birds"
        "bisexual"
        "bizarro-fiction"
        "black-literature"
        "boarding-school"
        "bolivia"
        "bolsheviks"
        "books-about-books"
        "booze"
        "boys-love"
        "brain"
        "brazil"
        "brewing"
        "british-literature"
        "buddhism"
        "buffy-the-vampire-slayer"
        "bulgaria"
        "bulgarian-literature"
        "buses"
        "business"
        "butch-femme"
        "campus"
        "canada"
        "canadian-literature"
        "canon"
        "cars"
        "cartography"
        "cartoon"
        "category-romance"
        "catholic"
        "cats"
        "challenged-books"
        "chancellorsville-campaign"
        "chapter-books"
        "chemistry"
        "chess"
        "chick-lit"
        "children-s"
        "childrens"
        "childrens-classics"
        "china"
        "chinese-literature"
        "choose-your-own-adventure"
        "christian"
        "christian-contemporary-fiction"
        "christian-fiction"
        "christian-fiction-amish"
        "christian-historical-fiction"
        "christian-non-fiction"
        "christian-romance"
        "christian-romance-historical"
        "christianity"
        "christmas"
        "church"
        "church-history"
        "church-ministry"
        "cinderella"
        "cities"
        "civil-war"
        "civil-war-eastern-theater"
        "civil-war-history"
        "civil-war-western-theater"
        "class"
        "class-issues"
        "classic-literature"
        "classical-music"
        "classical-studies"
        "classics"
        "clean-romance"
        "climate-change"
        "climbing"
        "cocktails"
        "coding"
        "coin-collecting"
        "collections"
        "college"
        "comedy"
        "comic-book"
        "comic-strips"
        "comics"
        "comics-manga"
        "coming-of-age"
        "comix"
        "communication"
        "complementary-medicine"
        "computer-reference"
        "computer-science"
        "computers"
        "conservation"
        "consumer-economics"
        "contemporary"
        "contemporary-romance"
        "cookbooks"
        "cooking"
        "counter-culture"
        "cozy-mystery"
        "crafts"
        "crafty"
        "crime"
        "criticism"
        "crochet"
        "cross-dressing"
        "cthulhu-mythos"
        "cuisine"
        "culinary"
        "cult-classics"
        "cults"
        "cultural"
        "cultural-heritage"
        "cultural-studies"
        "curation"
        "currency"
        "cyberpunk"
        "cycling"
        "czech-literature"
        "danish"
        "dark"
        "dark-fantasy"
        "dc-comics"
        "death"
        "demons"
        "denmark"
        "design"
        "detective"
        "diary"
        "dictionaries"
        "diets"
        "dinosaurs"
        "disability"
        "disability-studies"
        "disabled-communities"
        "discipleship"
        "disease"
        "divination"
        "doctor-who"
        "dogs"
        "drag"
        "dragonlance"
        "dragons"
        "drama"
        "drawing"
        "drinking"
        "dungeons-and-dragons"
        "dungeons-and-dragons-manuals"
        "dutch-literature"
        "dying-earth"
        "dystopia"
        "earth"
        "earth-sciences"
        "eastern-philosophy"
        "ecclesiology"
        "ecology"
        "economics"
        "education"
        "edwardian"
        "egypt"
        "egyptian-literature"
        "electrical-engineering"
        "elizabethan-period"
        "emergency-services"
        "engineering"
        "english-literature"
        "entrepreneurship"
        "environment"
        "epic"
        "epic-fantasy"
        "epic-poetry"
        "erotic-historical-romance"
        "erotic-horror"
        "erotic-paranormal-romance"
        "erotic-romance"
        "erotica"
        "esoterica"
        "esp"
        "espionage"
        "essays"
        "ethnic"
        "ethnic-studies"
        "ethnicity"
        "european-history"
        "european-literature"
        "evangelism"
        "evolution"
        "f-m-f"
        "fables"
        "fae"
        "fairies"
        "fairy-tale-retellings"
        "fairy-tales"
        "faith"
        "family"
        "fandom"
        "fantasy"
        "fantasy-of-manners"
        "fantasy-romance"
        "fat"
        "fat-acceptance"
        "fat-studies"
        "feminism"
        "feminist-studies"
        "feminist-theory"
        "femslash"
        "ferries"
        "fiction"
        "field-guides"
        "figure-skating"
        "film"
        "finance"
        "financial-management"
        "finnish-literature"
        "fire-engines"
        "fire-services"
        "firefighters"
        "fitness"
        "flash-fiction"
        "folk-tales"
        "folklore"
        "food"
        "food-and-drink"
        "food-and-wine"
        "food-history"
        "food-preservation"
        "food-writing"
        "foodie"
        "football"
        "forgotten-realms"
        "fractured-fairy-tales"
        "france"
        "freight"
        "french-literature"
        "french-revolution"
        "frugal"
        "funnies"
        "funny"
        "futurism"
        "futuristic"
        "futuristic-romance"
        "game-design"
        "gamebooks"
        "games"
        "gaming"
        "gaming-fiction"
        "gardening"
        "gastronomy"
        "gay"
        "gay-and-lesbian"
        "gay-for-you"
        "geek"
        "gemstones"
        "gender"
        "gender-and-sexuality"
        "gender-identity"
        "gender-roles"
        "gender-studies"
        "genderfuck"
        "genetics"
        "geography"
        "geology"
        "georgian"
        "georgian-romance"
        "german-literature"
        "germany"
        "ghost-stories"
        "ghosts"
        "glbt"
        "global-warming"
        "gnosticism"
        "go"
        "god"
        "goddess"
        "gods"
        "golden-age-mystery"
        "google"
        "goth"
        "gothic"
        "gothic-horror"
        "gothic-romance"
        "government"
        "grad-school"
        "graffiti"
        "graphic-literature"
        "graphic-non-fiction"
        "graphic-novels"
        "graphic-novels-comics"
        "graphic-novels-comics-manga"
        "graphic-novels-manga"
        "graphica"
        "greece"
        "greek-mythology"
        "green"
        "grimm"
        "growth-mindset"
        "guidebook"
        "guides"
        "hackers"
        "halloween"
        "hard-boiled"
        "hard-science-fiction"
        "harlequin"
        "health"
        "health-care"
        "herbs"
        "heritage-preservation"
        "heroic-fantasy"
        "high-fantasy"
        "high-school"
        "hinduism"
        "hip-hop"
        "historical"
        "historical-fantasy"
        "historical-fiction"
        "historical-mystery"
        "historical-romance"
        "history"
        "history-american-civil-war"
        "history-and-politics"
        "history-civil-war-eastern-theater"
        "history-of-science"
        "hockey"
        "holiday"
        "holland"
        "holocaust"
        "horror"
        "horse-racing"
        "horses"
        "horticulture"
        "how-to"
        "huguenots"
        "humanities"
        "humor"
        "humor-and-comedy"
        "hungarian-literature"
        "hungary"
        "hydrogeology"
        "illness"
        "india"
        "indian-literature"
        "indigenous-history"
        "indonesian-literature"
        "informatics"
        "information-science"
        "inspirational"
        "intensive-care"
        "international"
        "international-literature"
        "internet"
        "interracial-romance"
        "intersex"
        "iran"
        "ireland"
        "irish-literature"
        "islam"
        "islamic-terrorism"
        "islamism"
        "israel"
        "italian-literature"
        "italy"
        "japan"
        "japanese-history"
        "japanese-literature"
        "jazz"
        "jewellery"
        "jewellery-making"
        "jewish"
        "josei"
        "journal"
        "journaling"
        "journalism"
        "judaica"
        "judaism"
        "juvenile"
        "kazakhstan"
        "kenya"
        "knitting"
        "komik"
        "labor"
        "landscaping"
        "language"
        "lapidary"
        "latin-american"
        "latin-american-history"
        "latin-american-literature"
        "law"
        "lds"
        "lds-fiction"
        "lds-non-fiction"
        "leadership"
        "lebanon"
        "legal-thriller"
        "lenin"
        "leningrad"
        "lesbian"
        "lesbian-fiction"
        "lesbian-romance"
        "lesbotronic"
        "librarianship"
        "library-science"
        "light-novel"
        "list?filter=none&amp;page=1"
        "list?filter=none&amp;page=2"
        "list?filter=none&amp;page=3"
        "list?filter=none&amp;page=4"
        "literary-criticism"
        "literary-fiction"
        "literature"
        "local-history"
        "logic"
        "london-underground"
        "love"
        "love-inspired"
        "love-inspired-historical"
        "love-inspired-suspense"
        "love-story"
        "lovecraftian"
        "loveswept"
        "low-fantasy"
        "luxemburg"
        "m-f-f"
        "m-f-m"
        "m-m-contemporary"
        "m-m-f"
        "m-m-m"
        "m-m-m-f"
        "m-m-paranormal"
        "m-m-romance"
        "magic"
        "magical-realism"
        "magick"
        "mail-order-brides"
        "management"
        "manga"
        "manga-romance"
        "manhwa"
        "mannerpunk"
        "maps"
        "marathi"
        "maritime"
        "marriage"
        "martyr"
        "martyrdom"
        "marvel"
        "material-culture"
        "mathematics"
        "media-tie-in"
        "medical"
        "medicine"
        "medieval"
        "medieval-romance"
        "memoir"
        "menage"
        "mental-health"
        "mental-illness"
        "mermaids"
        "metaphysics"
        "microhistory"
        "middle-ages"
        "middle-grade"
        "military"
        "military-history"
        "military-science-fiction"
        "mills-and-boon"
        "mineralogy"
        "mmorpg"
        "modern"
        "modern-classics"
        "money"
        "money-management"
        "mormonism"
        "moscow"
        "motorcycle"
        "motorcycling"
        "mountaineering"
        "movies"
        "multicultural-literature"
        "multiple-partners"
        "murder-mystery"
        "muscovy"
        "museology"
        "museums"
        "music"
        "music-biography"
        "musicals"
        "musician-erotica"
        "musicians"
        "muslimah"
        "muslims"
        "mystery"
        "mystery-thriller"
        "mysticism"
        "mythology"
        "native-american-history"
        "native-americans"
        "natural-history"
        "nature"
        "near-future"
        "nerd"
        "neuroscience"
        "new-adult"
        "new-age"
        "new-testament"
        "new-weird"
        "new-york"
        "noir"
        "non-fiction"
        "nordic-noir"
        "norman"
        "north-american-history"
        "novella"
        "novels"
        "nsfw"
        "numismatics"
        "nursery-rhymes"
        "nursing"
        "nutrition"
        "occult"
        "occult-detective"
        "old-testament"
        "oral-history"
        "origami"
        "ornithology"
        "outdoors"
        "paganism"
        "pakistan"
        "palaeontology"
        "palaeozoology"
        "paranormal"
        "paranormal-mystery"
        "paranormal-romance"
        "paranormal-urban-fantasy"
        "parenting"
        "peak-oil"
        "pediatricians"
        "pediatrics"
        "personal-development"
        "personal-finance"
        "petrograd"
        "philosophy"
        "photography"
        "physics"
        "picture-books"
        "picu"
        "pirates"
        "planetary-romance"
        "planetary-science"
        "planets"
        "plantagenet"
        "plants"
        "plays"
        "plus-size"
        "poetry"
        "poland"
        "police"
        "polish-literature"
        "political-science"
        "politics"
        "polyamorous"
        "polyamory"
        "pop-culture"
        "popular-science"
        "pornography"
        "portugal"
        "portuguese-literature"
        "post-apocalyptic"
        "poverty"
        "pre-k"
        "prehistoric"
        "prehistory"
        "preservation"
        "presidents"
        "princesses"
        "productivity"
        "professors"
        "programming"
        "programming-languages"
        "prostitution"
        "psychological-thriller"
        "psychology"
        "public-transport"
        "pulp"
        "pulp-adventure"
        "pulp-noir"
        "punk"
        "punx"
        "puzzles"
        "quantum-mechanics"
        "queer"
        "queer-lit"
        "queer-studies"
        "quilting"
        "rabbits"
        "race"
        "racing"
        "railway-history"
        "railways"
        "read-for-college"
        "read-for-school"
        "real-person-fiction"
        "realistic-fiction"
        "realistic-young-adult"
        "recreation"
        "reference"
        "regency"
        "regency-romance"
        "relationships"
        "religion"
        "research"
        "retellings"
        "road-trip"
        "robots"
        "rock-n-roll"
        "role-playing-games"
        "roman"
        "roman-britain"
        "romance"
        "romania"
        "romanian-literature"
        "romanovs"
        "romantic"
        "romantic-suspense"
        "rus"
        "russia"
        "russian-empire"
        "russian-federation"
        "russian-history"
        "russian-literature"
        "russian-revolution"
        "satanism"
        "scandinavian-literature"
        "school"
        "school-stories"
        "science"
        "science-fiction"
        "science-fiction-fantasy"
        "science-fiction-romance"
        "science-nature"
        "scooters"
        "scores"
        "scotland"
        "scripture"
        "seinen"
        "self-help"
        "sequential-art"
        "serbian-literature"
        "sewing"
        "sex-and-erotica"
        "sex-work"
        "sexuality"
        "shapeshifters"
        "shinigami"
        "shojo"
        "shonen"
        "short-stories"
        "short-story-collection"
        "shounen-ai"
        "siege-of-petersburg"
        "silhouette"
        "singularity"
        "skepticism"
        "slash-fiction"
        "slice-of-life"
        "soccer"
        "social"
        "social-change"
        "social-issues"
        "social-justice"
        "social-media"
        "social-movements"
        "social-science"
        "society"
        "sociology"
        "software"
        "soldiers"
        "southern"
        "southern-gothic"
        "southern-war-for-independance"
        "soviet-history"
        "soviet-union"
        "space"
        "space-opera"
        "spain"
        "spanish-literature"
        "speculative-fiction"
        "spider-man"
        "spiritualism"
        "spirituality"
        "splatterpunk"
        "sports"
        "sports-and-games"
        "sports-romance"
        "spy-thriller"
        "st-petersburg"
        "star-trek"
        "star-trek-deep-space-nine"
        "star-trek-enterprise"
        "star-trek-original-series"
        "star-trek-the-next-generation"
        "star-trek-voyager"
        "star-wars"
        "steam-trains"
        "steampunk"
        "steampunk-romance"
        "storytime"
        "street-art"
        "strippers"
        "stuart"
        "students"
        "suisse"
        "sunday-comics"
        "superheroes"
        "superman"
        "supernatural"
        "superstition"
        "surreal"
        "survival"
        "suspense"
        "sustainability"
        "swashbuckling"
        "sweden"
        "swedish-literature"
        "sword-and-planet"
        "sword-and-sorcery"
        "taoism"
        "tarot"
        "tasmania"
        "tea"
        "teachers"
        "teaching"
        "technical"
        "technology"
        "teen"
        "terrorism"
        "textbooks"
        "the-1700s"
        "the-world"
        "theatre"
        "thelema"
        "theology"
        "theory"
        "theosophy"
        "threesome"
        "thriller"
        "time-travel"
        "time-travel-romance"
        "traditional-regency"
        "tragedy"
        "trains"
        "trans"
        "transgender"
        "transport"
        "transsexual"
        "travel"
        "travelogue"
        "trivia"
        "trucks"
        "true-crime"
        "true-story"
        "tsars"
        "tudor"
        "tudor-period"
        "turkish"
        "turkish-literature"
        "tv"
        "ukraine"
        "ukrainian-literature"
        "underground-railway"
        "unicorns"
        "united-states"
        "urban"
        "urban-fantasy"
        "urban-legends"
        "urban-planning"
        "urban-studies"
        "urbanism"
        "us-presidents"
        "usability"
        "utopia"
        "vampire-hunters"
        "vampires"
        "vegan"
        "vegetarian"
        "vegetarianism"
        "vespa"
        "victorian"
        "victorian-romance"
        "video-games"
        "viking-romance"
        "visual-art"
        "walking"
        "war"
        "warcraft"
        "web"
        "web-design"
        "webcomic"
        "weird-fiction"
        "werecats"
        "werewolves"
        "western"
        "western-historical-romance"
        "western-romance"
        "whodunit"
        "wicca"
        "wilderness"
        "wildlife"
        "wine"
        "witchcraft"
        "witches"
        "wizards"
        "wolves"
        "women-and-gender-studies"
        "womens"
        "womens-fiction"
        "womens-rights"
        "womens-studies"
        "wonder-woman"
        "woodwork"
        "words"
        "world-history"
        "world-of-darkness"
        "world-of-warcraft"
        "world-war-i"
        "world-war-ii"
        "writing"
        "x-men"
        "yaoi"
        "young-adult"
        "young-adult-contemporary"
        "young-adult-fantasy"
        "young-adult-historical-fiction"
        "young-adult-paranormal"
        "young-adult-romance"
        "young-adult-science-fiction"
        "young-readers"
        "yuri"
        "zen"
        "zombies"
    |]