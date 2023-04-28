let balls = [];
let gravity = 0.9;
let wind = 0.0;

// synth parameters
let env;
let osc;
let delay;

// envelope parameters 
let t1 = 0.01; // attack time in seconds
let l1 = 0.7; // attack level 0.0 to 1.0
let t2 = 0.1; // decay time in seconds
let l2 = 0.0; // decay level  0.0 to 1.0

function setup() {
  createCanvas(windowWidth, windowHeight);
  background(0);
  
  // currently set to 1 ball, this can be changed to any number
  for (let i = 0; i < 1; i++) {
    balls.push(new Ball());
  }

  // set up oscillator
  env = new p5.Envelope(t1, l1, t2, l2);
  osc = new p5.Oscillator('square')
  osc.amp(0.5);

  // set up delay
  delay = new p5.Delay();
  delay.process(osc, 0.99, 0.7, 750); // (input, delay time, feedback, filter cutoff)
  delay.setType('pingPong')
}

function windowResize() {
  resizeCanvas(windowWidth, windowHeight);
  background(0);
}

function playSound() {
  osc.start();
  env.play(osc);
}

function draw() {
  background(0, 0, 0, 30);

  // user instructions
  textSize(56);
  strokeWeight(1);
  stroke(100,100,100,50);
  text("use arrow keys to move around", 30, 60);

  noFill();
  strokeWeight(5);
  stroke(255);

  for (let i = 0; i < balls.length; i++) {
    balls[i].move();
    balls[i].display();

    let freq = map(balls[i].x, 0, width, 55, 220);
    osc.freq(freq);
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
}

// ball class
class Ball {
  constructor(x,y) {
    this.x = random(width); // position
    this.y = random(height); // position
    this.dx = random(-5,5); // velocity
    this.dy = 5; // velocity
    this.r = 300; // radius
    this.bounciness = 0.5;
    this.history = [] // array for trailing circles
  }

  move() {
    this.x += this.dx;
    this.y += this.dy;
    this.dx += wind;
    this.dy += gravity;

    // set up trailing circles
    let v = createVector(this.x, this.y);
    this.history.push(v);

    if (this.history.length > 2) {
      this.history.splice(0, 1);
    }

    // "tunnel" effect
    for (let i = 0; i < this.history.length; i++) {
          this.r *= cos(7.02) / 3;

          if (this.r <= 1) {
            this.r *= 300;
          }
    }

    // boundary collision
    // upper boundary
    if (this.y - this.r < 0) 
        {
            this.y = this.r;
            this.dy = this.dy * -1 * this.bounciness;

            // trigger synth
            playSound();
        }

    // lower boundary
    if (this.y - this.r > windowHeight) 
        {
            this.y = windowHeight - this.r;
            this.dy = this.dy * -1 * this.bounciness;

            // trigger synth
            playSound();
        }

    // left boundary
    if (this.x - this.r < 0) 
        {
            this.x = this.r;
            this.dx = this.dx * -1 * this.bounciness;

            // trigger synth
            playSound();
        } 
    
    // right boundary
    if (this.x - this.r > windowWidth) 
        {
            this.x = windowWidth - this.r;
            this.dx = this.dx * -1 * this.bounciness;

            // trigger synth
            playSound();
        }
    }

  display() {
    ellipse(this.x, this.y, this.r * 2, this.r * 2);

    for (let i = 0; i < this.history.length; i++) {
      let pos = this.history[i];
      ellipse(pos.x, pos.y, this.r * 2, this.r * 2);
    }
  }
}
