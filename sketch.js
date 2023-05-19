let particles = [];

function setup() {
  createCanvas(windowWidth, windowHeight);
  for (let i = 0; i < 666; i++) {
    particles.push(new Particle(random(width), random(height)));
  }
}

function draw() {
  background(0);
  for (let particle of particles) {
    particle.update();
    particle.display();
    particle.checkBoundaryCollision();
  }
}

class Particle {
    constructor(x, y) {
      this.position = createVector(x, y);
      this.velocity = createVector(x, y);
      this.acceleration = createVector(0, 0);
      this.mass = random(1, 5);
      this.size = this.mass * 5;
      this.maxSpeed = 1.5;
      this.maxForce = 1;
    }
  
    update() {
      this.velocity.add(this.acceleration);
      this.velocity.limit(this.maxSpeed);
      this.position.add(this.velocity);
      this.acceleration.mult(0.1);
    }
  
    applyForce(force) {
      let f = p5.Vector.div(force, this.mass);
      this.acceleration.add(f);
    }
  
    display() {
      fill(255);
      noStroke();
      ellipse(this.position.x, this.position.y, this.size, this.size);
    }

    checkBoundaryCollision() {
        if (this.position.x > width - this.size) {
          this.position.x = width - this.size;
          this.velocity.x *= -1;
        } else if (this.position.x < this.size) {
          this.position.x = this.size;
          this.velocity.x *= -1;
        } else if (this.position.y > height - this.size) {
          this.position.y = height - this.size;
          this.velocity.y *= -1;
        } else if (this.position.y < this.size) {
          this.position.y = this.size;
          this.velocity.y *= -1;
        }
      }
  }

  function mouseMoved() {
    let cursor = createVector(mouseX, mouseY);
    for (let particle of particles) {
      let direction = p5.Vector.sub(cursor, particle.position);
      let distance = direction.mag(0);
      let strength = map(distance, 0, 500, 1, 0);
      direction.normalize();
      let magneticForce = direction.mult(strength);
      particle.applyForce(magneticForce);
    }
  }