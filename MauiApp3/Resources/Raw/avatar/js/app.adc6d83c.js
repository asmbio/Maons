(function(){"use strict";var o={9050:function(o,e,t){var r=t(9242),n=t(3396);function i(o,e,t,r,i,p){const a=(0,n.up)("HelloWorld");return(0,n.wg)(),(0,n.j4)(a,{msg:"Welcome to Your Vue.js App"})}const p=(0,n._)("label",{class:"btn",for:"uploads"},"点击选择图片",-1);function a(o,e,t,i,a,c){const u=(0,n.up)("vue-cropper");return(0,n.wg)(),(0,n.iD)(n.HY,null,[(0,n.wy)((0,n.Wm)(u,{ref:"cropper",img:a.option.img,"output-size":a.option.size,"output-type":a.option.outputType,info:!0,full:a.option.full,fixed:a.fixed,"fixed-number":a.fixedNumber,"can-move":a.option.canMove,"can-move-box":a.option.canMoveBox,"fixed-box":a.option.fixedBox,original:a.option.original,"auto-crop":a.option.autoCrop,"auto-crop-width":a.option.autoCropWidth,"auto-crop-height":a.option.autoCropHeight,"center-box":a.option.centerBox,onRealTime:c.realTime,high:a.option.high,onImgLoad:c.imgLoad,mode:"cover","max-img-size":a.option.max,onCropMoving:c.cropMoving},null,8,["img","output-size","output-type","full","fixed","fixed-number","can-move","can-move-box","fixed-box","original","auto-crop","auto-crop-width","auto-crop-height","center-box","onRealTime","high","onImgLoad","max-img-size","onCropMoving"]),[[r.F8,a.model]]),(0,n.wy)((0,n._)("div",null,[p,(0,n._)("input",{ref:"file",type:"file",id:"uploads",style:{position:"absolute",clip:"rect(0 0 0 0)"},accept:"image/png, image/jpeg, image/gif, image/jpg",onChange:e[0]||(e[0]=o=>c.uploadImg(o,1))},null,544)],512),[[r.F8,!a.model]])],64)}var c={name:"HelloWorld",props:{},data(){return{model:!1,modelSrc:"",crap:!1,option:{img:"",size:1,full:!0,outputType:"jpg",canMove:!0,fixedBox:!0,original:!1,canMoveBox:!1,autoCrop:!0,autoCropWidth:160,autoCropHeight:160,centerBox:!1,high:!0,max:99999},show:!0,fixed:!0,fixedNumber:[16,16]}},methods:{changeImg(o){this.option.img=o},startCrop(){this.crap=!0,this.$refs.cropper.startCrop()},stopCrop(){this.crap=!1,this.$refs.cropper.stopCrop()},clearCrop(){this.$refs.cropper.clearCrop()},refreshCrop(){this.$refs.cropper.refresh()},changeScale(o){o=o||1,this.$refs.cropper.changeScale(o)},rotateLeft(){this.$refs.cropper.rotateLeft()},rotateRight(){this.$refs.cropper.rotateRight()},finish(o){"blob"===o?this.$refs.cropper.getCropBlob((o=>{console.log(o);var e=window.URL.createObjectURL(o);this.model=!0,this.modelSrc=e})):this.$refs.cropper.getCropData((o=>{this.model=!0,this.modelSrc=o}))},realTime(o){this.previews=o,console.log(o)},down(o){if("blob"!==o)return this.$refs.cropper.getCropData((o=>{this.downImg=o,console.log(this.downImg)})).then((()=>this.downImg));this.$refs.cropper.getCropBlob((o=>{this.downImg=window.URL.createObjectURL(o)}))},uploadImg(o,e){this.model=!0;var t=o.target.files[0];if(!/\.(gif|jpg|jpeg|png|bmp|GIF|JPG|PNG)$/.test(o.target.value))return alert("图片类型必须是.gif,jpeg,jpg,png,bmp中的一种"),!1;var r=new FileReader;r.onload=o=>{let t;t="object"===typeof o.target.result?window.URL.createObjectURL(new Blob([o.target.result])):o.target.result,1===e?this.option.img=t:2===e&&(this.example2.img=t)},r.readAsArrayBuffer(t)},imgLoad(o){console.log(o)},cropMoving(o){console.log(o,"截图框当前坐标")}},mounted:function(){window.avatar=this,console.log(window["vue-cropper"])}},u=t(89);const l=(0,u.Z)(c,[["render",a]]);var s=l,f={name:"App",components:{HelloWorld:s}};const g=(0,u.Z)(f,[["render",i]]);var h=g,d=t(5276);const m=(0,r.ri)(h);m.use(d.ZP),m.mount("#app")}},e={};function t(r){var n=e[r];if(void 0!==n)return n.exports;var i=e[r]={exports:{}};return o[r](i,i.exports,t),i.exports}t.m=o,function(){var o=[];t.O=function(e,r,n,i){if(!r){var p=1/0;for(l=0;l<o.length;l++){r=o[l][0],n=o[l][1],i=o[l][2];for(var a=!0,c=0;c<r.length;c++)(!1&i||p>=i)&&Object.keys(t.O).every((function(o){return t.O[o](r[c])}))?r.splice(c--,1):(a=!1,i<p&&(p=i));if(a){o.splice(l--,1);var u=n();void 0!==u&&(e=u)}}return e}i=i||0;for(var l=o.length;l>0&&o[l-1][2]>i;l--)o[l]=o[l-1];o[l]=[r,n,i]}}(),function(){t.n=function(o){var e=o&&o.__esModule?function(){return o["default"]}:function(){return o};return t.d(e,{a:e}),e}}(),function(){t.d=function(o,e){for(var r in e)t.o(e,r)&&!t.o(o,r)&&Object.defineProperty(o,r,{enumerable:!0,get:e[r]})}}(),function(){t.g=function(){if("object"===typeof globalThis)return globalThis;try{return this||new Function("return this")()}catch(o){if("object"===typeof window)return window}}()}(),function(){t.o=function(o,e){return Object.prototype.hasOwnProperty.call(o,e)}}(),function(){var o={143:0};t.O.j=function(e){return 0===o[e]};var e=function(e,r){var n,i,p=r[0],a=r[1],c=r[2],u=0;if(p.some((function(e){return 0!==o[e]}))){for(n in a)t.o(a,n)&&(t.m[n]=a[n]);if(c)var l=c(t)}for(e&&e(r);u<p.length;u++)i=p[u],t.o(o,i)&&o[i]&&o[i][0](),o[i]=0;return t.O(l)},r=self["webpackChunkavatar"]=self["webpackChunkavatar"]||[];r.forEach(e.bind(null,0)),r.push=e.bind(null,r.push.bind(r))}();var r=t.O(void 0,[998],(function(){return t(9050)}));r=t.O(r)})();
//# sourceMappingURL=app.adc6d83c.js.map