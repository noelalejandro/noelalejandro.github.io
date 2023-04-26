// Ball class
class Ball {
  constructor() {
    this.x = width/2;
    this.y = 25;
    this.dx = random(-20,20);
    this.dy = 20;
    this.bounciness = 0.75;
    this.diameter = 50;
  }

  move() {
    this.x += this.dx;
    this.y += this.dy;
    this.dx += wind;
    this.dy += gravity;
    this.dx = this.dx * hold;
    this.dy = this.dy * hold;
  }

  display() {
    ellipse(this.x, this.y, this.diameter, this.diameter);
  }
  
  checkBoundaryCollision() {
    if (this.x > displayWidth - this.diameter/2) {
      this.x = displayWidth - this.diameter/2;
      this.dx *= -this.dx * bounciness;
    } else if (this.x < this.diameter/2) {
      this.x = this.diameter/2;
      this.dx *= -this.dx * bounciness;
    } else if (this.y > displayHeight - this.diameter/2) {
      this.y = displayHeight - this.diameter/2;
      this.dy *= -this.dy * bounciness;
    } else if (this.y < this.diameter) {
      this.y = this.diameter;
      this.y *= -this.dy * bounciness;
    }
  }
}

let balls = [];

function setup() {
  createCanvas(disaplayWidth, displayHeight);
  // Create objects
  for (let i = 0; i < 50; i++) {
    balls.push(new Ball());
  }
}

function draw() {
  background(50, 89, 100);
  for (let i = 0; i < balls.length; i++) {
    balls[i].move();
    balls[i].display();
  }
}

//=============================================================

let gravity = 0.9;
let wind = 0.0;
let hold = 1;

function keyPressed()
{
//   if (key == ' ')
//   {
//     // new ball
//     Ball b = bouncingBall();
//     balls.add(b);
//   }
  
  if (key == CODED) 
  {
    if (keyCode == UP) 
    {
      gravity = gravity - 0.25;
    }
    if (keyCode == DOWN)
    {
      gravity = gravity + 0.25;
    }
    if (keyCode == LEFT) 
    {
      wind = wind - 0.25;
    }
    if (keyCode == RIGHT)
    {
      wind = wind + 0.25;
    }
//     if (keyCode == ESC)
//     {
      // stop the program
    }
  }
}
