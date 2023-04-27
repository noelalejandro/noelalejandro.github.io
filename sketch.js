let balls = [];
let gravity = 0.9;
let wind = 0.0;
let hold = 1;

let t1 = 0.01; // attack time in seconds
let l1 = 0.7; // attack level 0.0 to 1.0
let t2 = 0.1; // decay time in seconds
let l2 = 0.0; // decay level  0.0 to 1.0

let env;
let osc;

function setup() {
  createCanvas(1425, 750);
  // 
  for (let i = 0; i < 1; i++) {
    balls.push(new Ball());
  }
  env = new p5.Envelope(t1, l1, t2, l2);
  osc = new p5.Oscillator('sine')
  osc.amp(0.5);

  delay = new p5.Delay();
  delay.process(osc, 0.5, 0.7, 1000); // (input, delay time, feedback, filter cutoff)
  delay.setType('pingPong')
}

function playSound() {
  osc.start();
  env.play(osc);
}

function draw() {
  background(50, 50, 50);
  for (let i = 0; i < balls.length; i++) {
    balls[i].move();
    balls[i].display();
  }

  if (keyIsDown(UP_ARROW)) {
    gravity = gravity - 0.05;
  }
  if (keyIsDown(DOWN_ARROW)){
    gravity = gravity + 0.05;
  }
  if (keyIsDown(LEFT_ARROW)){
    wind = wind - 0.05;
  }
  if (keyIsDown(RIGHT_ARROW)){
    wind = wind + 0.05;
  }

  function mousePressed() {
    if (hold == 1) {
      hold = 0;
    } else {
      hold = 1;
    }
  }
  
  function mouseReleased() {
    if (hold == 1) {
      hold = 0;
    } else {
      hold = 1;
    }
  }
}

// Ball class
class Ball {
  constructor() {
    this.x = random(width); //position
    this.y = random(height); //position
    this.dx = random(-5,5); //velocity
    this.dy = 5; //velocity
    this.r = 25; //radius
    this.bounciness = 0.5;
  }

  move() {
    this.x += this.dx;
    this.y += this.dy;
    this.dx += wind;
    this.dy += gravity;
    this.dx = this.dx * hold;
    this.dy = this.dy * hold;

    // Boundary Collision
    if (this.y - this.r < 0) 
        {
            this.y = this.r;
            this.dy = this.dy * -1 * this.bounciness;

            osc.start();
            env.play(osc);
        }
    if (this.y - this.r > height) 
        {
            this.y = height - this.r;
            this.dy = this.dy * -1 * this.bounciness;

            osc.start();
            env.play(osc);
        }
    if (this.x - this.r < 0) 
        {
            this.x = this.r;
            this.dx = this.dx * -1 * this.bounciness;

            osc.start();
            env.play(osc);
        } 
    if (this.x - this.r > width) 
        {
            this.x = width - this.r;
            this.dx = this.dx * -1 * this.bounciness;

            osc.start();
            env.play(osc);
        }
    }

  display() {
    ellipse(this.x, this.y, this.r * 2, this.r * 2);
  }
}
