const { series, src, dest } = require('gulp');

const cp = require('child_process');

function defaultTask(cb) {
	cb();
}

function construir(cb) {
	cp.exec('quasar build', function(err, stdout, stderr) {
		console.log(stdout);
		console.log(stderr);
		cb(err);
	});
}

function copiarDist(cb) {
	return src('dist/spa-mat/**')
		.pipe(dest('../dist/'));
}

function copiarSrc(cb) {
	return src('src/**')
		.pipe(dest('../src/'));
}

exports.default = series(construir, copiarDist);//, copiarSrc);
// exports.default = copiarDist;
