var game = new Phaser.Game(800, 600, Phaser.CANVAS, 'phaser-example', { preload: preload, create: create, update: update, render: render });

function preload() {
    game.load.image('backround', 'assets/long_backround.png');
    game.load.image('house1', 'assets/house1.png');
    game.load.image('house2', 'assets/house2.png');
    game.load.image('house3', 'assets/house3.png');
    game.load.image('house4', 'assets/house4.png');
    game.load.image('house5', 'assets/house5.png');
    game.load.image('house6', 'assets/house6.png');
    game.load.image('house7', 'assets/house7.png');
    game.load.image('burger', 'assets/burger.png');
    game.load.image('fries', 'assets/fries.png');
    game.load.image('icecream', 'assets/icecream.png');
    game.load.image('soda', 'assets/soda.png');
    game.load.image('bag', 'assets/bag.png');
    game.load.image('platform', 'assets/platform.png');
    game.load.image('long_platform', 'assets/long_platform.png');
    game.load.image('enemy', 'assets/villian.png');
    game.load.image('franky', 'assets/franky.png');
    game.load.spritesheet('chibi', 'assets/chibi_walking_andattack.png', 400, 375, 16);
}

var character;
var checkEnemy;
var enemies;
var platforms;
var sidewalk;
var food;
var cursors;
var jump;
var animation;
var life = 100;

function create() {
    game.physics.startSystem(Phaser.Physics.ARCADE);    
    
    game.world.setBounds(0, 0, 7500, 600);
    
    var backround = game.add.image(-55, -40, 'backround');
    backround.scale.set(1.5);
    
    var houses = game.add.group();
    var house = houses.create(500, 295, 'house1').scale.set(3);
    house = houses.create(1500, 325, 'house2');
    house.scale.set(3);
    house = houses.create(2500, 325, 'house3');
    house.scale.set(3);
    house = houses.create(3500, 345, 'house4');
    house.scale.set(3);
    house = houses.create(4500, 290, 'house5');
    house.scale.set(3);
    house = houses.create(5500, 380, 'house6');
    house.scale.set(3);
    house = houses.create(6500, 285, 'house7');
    house.scale.set(3);
    
    platforms = game.add.group();
    platforms.enableBody = true;
    
    platforms.create(350, 425, 'platform').body.immovable = true;
    platforms.create(500, 360, 'platform').body.immovable = true;
    platforms.create(650, 290, 'platform').body.immovable = true;
    platforms.create(1400, 400, 'platform').body.immovable = true;
    platforms.create(1600, 300, 'platform').body.immovable = true;
    platforms.create(1800, 400, 'platform').body.immovable = true;
    platforms.create(3000, 400, 'platform').body.immovable = true;
    platforms.create(3250, 325, 'platform').body.immovable = true;
    platforms.create(3000, 250, 'platform').body.immovable = true;
    platforms.create(3250, 175, 'platform').body.immovable = true;
    platforms.create(4200, 450, 'platform').body.immovable = true;
    platforms.create(4400, 350, 'platform').body.immovable = true;
    platforms.create(4600, 250, 'platform').body.immovable = true;
    platforms.create(5800, 250, 'platform').body.immovable = true;
    platforms.create(6000, 350, 'platform').body.immovable = true;
    platforms.create(6200, 450, 'platform').body.immovable = true;
    platforms.create(900, 300, 'long_platform').body.immovable = true;
    platforms.create(2300, 400, 'long_platform').body.immovable = true;
    platforms.create(3500, 150, 'long_platform').body.immovable = true;
    platforms.create(4800, 200, 'long_platform').body.immovable = true;
    platforms.create(4990, 200, 'long_platform').body.immovable = true;
    platforms.create(5180, 200, 'long_platform').body.immovable = true;
    platforms.create(5370, 200, 'long_platform').body.immovable = true;
    platforms.create(5560, 200, 'long_platform').body.immovable = true;
    
    var x = -10;
    for (var i = 0; i < 12; i++)
    {
        var sidewalk = platforms.create(x, 550, 'long_platform');
        sidewalk.scale.set(4, 1);
        sidewalk.body.immovable = true;
        x += 745;
    }
    
    food = game.add.group();
    food.enableBody = true;
    var create = food.create(1000, 250, 'soda');
    create.body.gravity.y = 300;
    create = food.create(1620, 250, 'fries');
    create.body.gravity.y = 300;
    create = food.create(3600, 100, 'bag');
    create.body.gravity.y = 300;
    create = food.create(5825, 175, 'icecream');
    create.body.gravity.y = 300;
    
    enemies = game.add.group();
    enemies.enableBody = true;
    
    checkEnemy = enemies.create(1000, 320, 'enemy');
    checkEnemy.body.gravity.y = 300;
    checkEnemy.body.setSize(60, 100, 30, 30);
    
    moveEnemy();
    
    var enemy = enemies.create(3800, 320, 'enemy');
    enemy.body.gravity.y = 300;
    enemy.body.setSize(60, 100, 30, 30);
    
    enemy = enemies.create(5250, 320, 'enemy');
    enemy.body.gravity.y = 300;
    enemy.body.setSize(60, 100, 30, 30);
    
    enemy = enemies.create(5250, 0, 'enemy');
    enemy.body.gravity.y = 300;
    enemy.body.setSize(60, 100, 30, 30);
    
    character = game.add.sprite(100, 300, 'chibi');
    character.scale.set(0.5);
    character.anchor.set(0.5);
    
    game.physics.arcade.enable(character);
    character.body.gravity.y = 300;
    character.body.setSize(100, 190, -5, 35);
    character.body.collideWorldBounds = true;
    character.animations.add('walk', [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15], 10, true);
    
    cursors = game.input.keyboard.createCursorKeys();
    jump = game.input.keyboard.addKey(Phaser.Keyboard.SPACEBAR);
    //game.camera.follow(character);
    
    var text = "Life: " + life;
    var print = game.add.text(32, 32, text, { fill: '#ffffff' });
}

function update() {
    game.physics.arcade.collide(character, platforms);
    game.physics.arcade.collide(enemies, platforms);
    game.physics.arcade.collide(food, platforms);
    game.physics.arcade.collide(character, food, eatFood, null, this);
    game.physics.arcade.collide(character, enemies, enemyCollide, null, this);
    character.body.velocity.x = 0;
    /*
    if (cursors.right.isDown)
    {
        character.animations.play('walk');
        character.body.velocity.x = 200;
        if (character.scale.x < 0)
        {
            character.scale.x *= -1;
        }
    }
    else if (cursors.left.isDown)
    {
        character.animations.play('walk');
        character.body.velocity.x -= 200;
        if (character.scale.x > 0)
        {
            character.scale.x *= -1;
        }
    }
    else
    {
        character.animations.stop();
    }
    
    if (jump.isDown && character.body.touching.down)
    {
        character.body.velocity.y = -300;
    }
    */
    
    if (cursors.right.isDown)
    {
        game.camera.x += 20;
    }
    else if (cursors.left.isDown)
    {
        game.camera.x -= 20;
    }
    
}

function eatFood (player, food) {
    food.kill();
    life += 10;
}

function enemyCollide () {
    life -= 10;
}

function moveEnemy() {
    var tween = game.add.tween(checkEnemy).to({ x: 500 }, 3000);
    //flipEnemy();
}

function flipEnemy() {
    if (checkEnemy.scale.x > 0)
    {
        checkEnemy.scale.x *= -1;
    }
    else if (checkEnemy.scale.x < 0)
    {
        checkEnemy.scale.x *= -1;
    }
}

function render() {
    game.debug.body(character);
}